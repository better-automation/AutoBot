using AutoBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot
{
    public abstract class AutoBotCommandBus : IAutoBotCommandBus
    {
        private readonly IAutoBotCommandLogger _logger;
        private readonly ISourceNavigator _navigator;

        public AutoBotCommandBus(ISourceNavigator navigator, IAutoBotCommandLogger logger)
        {
            _logger = logger;
            _navigator = navigator;
        }

        public virtual void ExecuteCommand(IAutoBotCommand command, string componentName)
        {
            _logger.LogVerbose($"Target component key is: { componentName }");

            string commandClassName = command.GetType().Name;

            _logger.LogVerbose($"Current command is: { commandClassName }");

            Source source = _navigator.GetCurrentSource();
            string sourceClassName = source.GetType().Name;

            _logger.LogVerbose($"Current source is: { sourceClassName }");

            object component = source.GetComponent(componentName);
            string componentClassName = component.GetType().Name;

            _logger.LogVerbose($"Current component is: { componentClassName }");

            command.Execute(component);

            _logger.LogVerbose($"{ componentName }::{ commandClassName }::{ sourceClassName }::{ componentClassName } command complete.");
        }

        public virtual TResult RunQuery<TResult>(IAutoBotQuery<TResult> query, string componentName)
        {
            _logger.LogVerbose($"Target component key is: { componentName }");

            string queryClassName = query.GetType().Name;
            
            _logger.LogVerbose($"Current query is: { queryClassName }");

            Source source = _navigator.GetCurrentSource();
            string sourceClassName = source.GetType().Name;

            _logger.LogVerbose($"Current source is: { sourceClassName }");

            object component = source.GetComponent(componentName);
            string componentClassName = component.GetType().Name;

            _logger.LogVerbose($"Current component is: { componentClassName }");

            TResult result = query.Run(component);

            _logger.LogVerbose($"{ componentName }::{ queryClassName }::{ sourceClassName }::{ componentClassName } query returned { result.ToString() }.");

            return result;
        }

        public abstract void FailTest(string message);
    }
}
