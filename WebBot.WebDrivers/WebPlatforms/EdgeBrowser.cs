using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebBot.WebDrivers.WebPlatforms
{
    public class EdgeBrowser : WebPlatform
    {
        public override string Name => "Edge";

        public override IWebDriver CreateWebDriver(WebDriverOptions options)
        {
            new DriverManager().SetUpDriver(new EdgeConfig());

            EdgeOptions edgeOptions = new EdgeOptions();

            if (options.RunHeadless)
            {
                // Edge Does Not Support Headless
            }

            return new EdgeDriver(edgeOptions);
        }
    }
}
