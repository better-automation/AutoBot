using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core.Exceptions
{
    public class ComponentNotFoundException : AutoBotException
    {
        public readonly string ComponentName;
        public readonly Source TargetSource;

        public ComponentNotFoundException(string componentName, Source source) 
            : base($"Component '{componentName}' not found in {source.Name}.")
        {
            ComponentName = componentName;
            TargetSource = source;
        }
    }
}
