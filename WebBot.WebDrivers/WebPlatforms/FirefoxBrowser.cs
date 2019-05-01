using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebBot.WebDrivers.WebPlatforms
{
    public class FirefoxBrowser : WebPlatform
    {
        public override string Name => "Firefox";
        
        private void StartMobile(IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("m").KeyUp(Keys.Shift).KeyUp(Keys.Control).Perform();
        }

        private FirefoxProfile CreateMobileProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("devtools.responsiveUI.presets", "[{\"width\": 800, \"name\": \"Mobile Device\", \"key\": \"800x600\", \"height\": 600}]");
            return profile;
        }

        public override IWebDriver CreateWebDriver(WebDriverOptions options)
        {
            new DriverManager().SetUpDriver(new FirefoxConfig(), version: "Latest", architecture: Architecture.X64);
            
            FirefoxOptions firefoxOptions = new FirefoxOptions();

            if (options.RunHeadless)
            {
                firefoxOptions.AddArguments("-headless", "--screenshots");
            }

            IWebDriver webDriver = new FirefoxDriver(firefoxOptions);

            if (options.Desktop)
            {
                webDriver.Manage().Window.Maximize();
            }
            else
            {
                webDriver.Manage().Window.Size = new Size(420, 600);
            }

            return webDriver;
        }
    }
}
