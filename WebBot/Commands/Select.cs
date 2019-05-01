using System;
using System.Collections.Generic;
using System.Text;
using AutoBot.Core;
using OpenQA.Selenium;

namespace WebBot.Commands
{
    public class Select : IAutoBotCommand
    {
        private readonly string _optionName;
        private readonly IWebDriver _webDriver;

        public Select(IWebDriver webDriver, string optionName)
        {
            _optionName = optionName;
            _webDriver = webDriver;
        }

        public void Execute(object component)
        {
            ((ISelectable)component).SelectOption(_webDriver, _optionName);
        }
    }
}
