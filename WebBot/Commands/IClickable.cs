using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands
{
    public interface IClickable
    {
        void Click(IWebDriver webDriver);
    }
}
