using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core.Exceptions
{
    public class AutoBotCommandFailedException : AggregateException
    {
        public IAutoBotCommand Command;
        public string ComponentName;

        public AutoBotCommandFailedException(IAutoBotCommand command, string componentName, IEnumerable<Exception> innerExceptions)
            : base($"{command.GetType().Name} command failed on '{componentName}'", innerExceptions)
        {
            Command = command;
            ComponentName = componentName;
        }
    }
}
