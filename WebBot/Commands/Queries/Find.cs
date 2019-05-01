using AutoBot.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands.Queries
{
    public class Find : IAutoBotQuery<bool>
    {
        private readonly IWebDriver _webDriver;

        public Find(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool Run(object component)
        {
            return ((IFindable)component).Find(_webDriver);
        }
    }
}
