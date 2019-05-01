using AutoBot.Core;
using AutoBot.Core.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands
{
    public class Click : IAutoBotCommand
    {
        private readonly IWebDriver _webDriver;

        public Click(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Execute(object component)
        {
            ((IClickable)component).Click(_webDriver);
        }
    }
}
