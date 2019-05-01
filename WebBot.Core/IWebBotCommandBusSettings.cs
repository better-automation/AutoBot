using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Core
{
    public interface IWebBotCommandBusSettings
    {
        int RetryIntervalMs { get; }
        int RetryTimeoutMs { get; }
    }
}
