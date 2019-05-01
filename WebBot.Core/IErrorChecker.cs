using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Core
{
    public interface IErrorChecker
    {
        string CheckScreenForErrorMessage(IWebDriver webDriver);
    }
}
