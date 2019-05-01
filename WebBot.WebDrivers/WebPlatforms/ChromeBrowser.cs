using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebBot.WebDrivers.WebPlatforms
{
    public class ChromeBrowser : WebPlatform
    {
        public override string Name => "Chrome";

        public override IWebDriver CreateWebDriver(WebDriverOptions options)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions chromeOptions = new ChromeOptions();

            if (!options.Desktop)
            {
                chromeOptions.EnableMobileEmulation("Nexus 5");
            }

            if (options.RunHeadless)
            {
                chromeOptions.AddArguments("headless", "disable-gpu");
            }

            IWebDriver webDriver = new ChromeDriver(chromeOptions); ;

            if (options.Desktop)
            {
                webDriver.Manage().Window.Maximize();
            }

            return webDriver;
        }
    }
}
