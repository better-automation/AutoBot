using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands
{
    public interface ISelectable
    {
        void SelectOption(IWebDriver webDriver, string optionName);
    }
}
