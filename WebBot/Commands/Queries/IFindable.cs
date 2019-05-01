using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Commands.Queries
{
    public interface IFindable
    {
        bool Find(IWebDriver webDriver);
    }
}
