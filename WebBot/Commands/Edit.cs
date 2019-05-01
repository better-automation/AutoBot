using System;
using System.Collections.Generic;
using System.Text;
using AutoBot.Core;
using OpenQA.Selenium;

namespace WebBot.Commands
{
    public class Edit : IAutoBotCommand
    {
        private readonly string _value;
        private readonly IWebDriver _webDriver;

        public Edit(IWebDriver webDriver, string value)
        {
            _value = value;
            _webDriver = webDriver;
        }

        public void Execute(object component)
        {
            ((IEditable)component).SetValue(_webDriver, _value);            
        }
    }
}
