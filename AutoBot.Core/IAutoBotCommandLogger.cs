using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public interface IAutoBotCommandLogger
    {
        void LogMessage(string message);
        void LogVerbose(string message);
    }
}
