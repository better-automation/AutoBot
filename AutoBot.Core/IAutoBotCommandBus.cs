using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public interface IAutoBotCommandBus
    {
        void ExecuteCommand(IAutoBotCommand command, string componentName);
        TResult RunQuery<TResult>(IAutoBotQuery<TResult> query, string componentName);
    }
}
