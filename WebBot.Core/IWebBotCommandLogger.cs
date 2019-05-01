using AutoBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Core
{
    public interface IWebBotCommandLogger : IAutoBotCommandLogger
    {
        void TakeScreenshot(string message = null);
    }
}
