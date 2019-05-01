using WebBot.WebDrivers.Exceptions;
using WebBot.WebDrivers.WebPlatforms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.WebDrivers
{
    public abstract class WebPlatform
    {
        public abstract string Name { get; }

        public static WebPlatform Create(string targetPlatformName)
        {
            switch (targetPlatformName.ToLower().Replace(" ", string.Empty))
            {
                case "edge":
                    return new EdgeBrowser();
                case "chrome":
                    return new ChromeBrowser();
                case "firefox":
                    return new FirefoxBrowser();
                default:
                    throw new TargetPlatformNotSupportedException(targetPlatformName);
            }
        }

        public abstract IWebDriver CreateWebDriver(WebDriverOptions options);
    }
}
