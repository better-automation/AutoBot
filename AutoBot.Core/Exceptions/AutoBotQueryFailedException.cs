using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core.Exceptions
{
    public class AutoBotQueryFailedException<TResult> : AggregateException
    {
        public IAutoBotQuery<TResult> Query;
        public string ComponentName;

        public AutoBotQueryFailedException(IAutoBotQuery<TResult> query, string componentName, IEnumerable<Exception> innerExceptions)
            : base($"{query.GetType().Name} query failed on '{componentName}'", innerExceptions)
        {
            Query = query;
            ComponentName = componentName;
        }
    }
}
