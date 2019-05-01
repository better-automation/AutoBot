using AutoBot.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public abstract class Source
    {
        protected abstract IDictionary<string, object> Components { get; }

        public abstract string Name { get; }

        public object GetComponent(string componentName)
        {
            if (!Components.TryGetValue(componentName, out object component))
            {
                throw new ComponentNotFoundException(componentName, this);
            }

            return component;
        }
    }
}
