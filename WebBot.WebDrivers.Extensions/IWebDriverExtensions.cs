using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.WebDrivers.Extensions
{
    public static class IWebDriverExtensions
    {
        public static IWebElement FindElementWhenVisible(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = null;

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(wd =>
            {
                try
                {
                    return webElement = webDriver.FindElement(by);
                }
                catch
                {
                    return null;
                }
            });

            return webElement;
        }

        
    }
}
