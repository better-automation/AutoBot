using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands
{
    public interface IEditable
    {
        void SetValue(IWebDriver webDriver, string value);
    }
}
