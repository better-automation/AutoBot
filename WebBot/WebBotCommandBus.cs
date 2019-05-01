using AutoBot;
using AutoBot.Core;
using AutoBot.Core.Exceptions;
using WebBot.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebBot
{
    public class WebBotCommandBus : AutoBotCommandBus
    {
        private readonly ISourceNavigator _navigator;
        private readonly IWebBotCommandLogger _logger;
        private readonly IWebBotCommandBusSettings _settings;
        private readonly IWebDriver _webDriver;

        private bool IsErrorMessageOnScreen(string commandOrQueryString)
        {
            if (_navigator is IErrorChecker errorChecker)
            {
                _logger.LogVerbose($"{ commandOrQueryString } Checking for error messages visible to user...");

                string errorMessage = errorChecker.CheckScreenForErrorMessage(_webDriver);

                if (errorMessage == null)
                {
                    _logger.LogVerbose($"{ commandOrQueryString }  No error message visible to user.");
                    return false;
                }

                FailTest($"{ commandOrQueryString } Error message is visible to user: {errorMessage}");
                return true;
            }

            return false;
        }

        private bool IsTimedOut(string commandOrQueryString, DateTime startTime)
        {
            double msRemaining = _settings.RetryTimeoutMs - DateTime.UtcNow.Subtract(startTime).TotalMilliseconds;

            if (msRemaining <= 0)
            {
                return true;
            }

            _logger.LogVerbose($"{ commandOrQueryString } Retrying again in { _settings.RetryIntervalMs.ToString() } ms. Timeout in { msRemaining } ms");

            Thread.Sleep(_settings.RetryIntervalMs);

            return false;
        }

        private Exception[] RunIterativelyAndCollectExceptions(string commandOrQueryString, Action action)
        {
            List<Exception> exceptions = new List<Exception>();

            DateTime started = DateTime.UtcNow;

            while (true)
            {
                try
                {
                    try
                    {
                        action();
                        return new Exception[0];
                    }
                    catch
                    {
                        if (IsErrorMessageOnScreen(commandOrQueryString))
                        {
                            break;
                        }

                        throw;
                    }
                }
                catch (WebDriverException webDriverException)
                {
                    exceptions.Add(webDriverException);
                }
                catch (AutoBotException autoBotException)
                {
                    exceptions.Add(autoBotException);
                }

                _logger.TakeScreenshot($"Warning: { commandOrQueryString } command could not be completed.");
                
                if (IsTimedOut(commandOrQueryString, started))
                {
                    break;
                }
            }

            return exceptions.ToArray();
        }
    
        public WebBotCommandBus(IWebDriver webDriver, ISourceNavigator navigator, IWebBotCommandLogger logger, IWebBotCommandBusSettings settings) : base(navigator, logger)
        {
            _logger = logger;
            _navigator = navigator;
            _settings = settings;
            _webDriver = webDriver;
        }

        public override void ExecuteCommand(IAutoBotCommand command, string componentName)
        {
            string commandString = $"{ componentName }::{ command.GetType().Name }";

            try
            {
                Exception[] exceptions = RunIterativelyAndCollectExceptions(commandString, () =>
                {
                    base.ExecuteCommand(command, componentName);
                });

                if (exceptions.Length > 0)
                {
                    throw new AutoBotCommandFailedException(command, componentName, exceptions);
                }
            }
            catch
            {
                _logger.TakeScreenshot($"ERROR: { commandString } Test Failed.");

                throw;
            }
        }

        public override TResult RunQuery<TResult>(IAutoBotQuery<TResult> query, string componentName)
        {
            string queryString = $"{ componentName }::{ query.GetType().Name }";

            try
            {
                TResult result = default(TResult);

                Exception[] exceptions = RunIterativelyAndCollectExceptions(queryString, () =>
                {
                    result = base.RunQuery(query, componentName);
                });

                if (exceptions.Length > 0)
                {
                    throw new AutoBotQueryFailedException<TResult>(query, componentName, exceptions);
                }

                return result;
            }
            catch
            {
                _logger.TakeScreenshot($"Error: { queryString } Test Failed.");

                throw;
            }
        }

        public override void FailTest(string message)
        {
            throw new Exception(message);
        }
    }
}
