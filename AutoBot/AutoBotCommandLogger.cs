using AutoBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot
{
    public abstract class AutoBotCommandLogger : IAutoBotCommandLogger
    {
        private readonly IAutoBotCommandLoggerSettings _settings;

        public AutoBotCommandLogger(IAutoBotCommandLoggerSettings settings)
        {
            _settings = settings;
        }

        public abstract void LogMessage(string message);

        public void LogVerbose(string message)
        {
            if (_settings.Verbose)
            {
                LogMessage(message);
            }
        }
    }
}
