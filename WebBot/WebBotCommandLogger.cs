using AutoBot.Core;
using WebBot.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using AutoBot;

namespace WebBot
{
    public abstract class WebBotCommandLogger : AutoBotCommandLogger, IWebBotCommandLogger
    {
        private readonly IAutoBotCommandLoggerSettings _settings;
        private readonly IWebDriver _webDriver;

        private void AddMessageToScreenshot(Image png, string message)
        {
            using (Graphics graphics = Graphics.FromImage(png))
            {
                graphics.DrawString(message, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(0f, 0f));
            }
        }

        public WebBotCommandLogger(IWebDriver webDriver, IAutoBotCommandLoggerSettings settings) 
            : base(settings)
        {
            _settings = settings;
            _webDriver = webDriver;
        }

        protected abstract void SaveScreenshot(byte[] png);

        public void TakeScreenshot(string message = null)
        {
            byte[] screenshotData = ((ITakesScreenshot)_webDriver).GetScreenshot().AsByteArray;

            using (MemoryStream stream = new MemoryStream(screenshotData))
            {
                Image png = Image.FromStream(stream);

                if (message != null)
                {
                    LogMessage(message);
                    AddMessageToScreenshot(png, message);
                }

                using (MemoryStream pngStream = new MemoryStream())
                {
                    png.Save(pngStream, ImageFormat.Png);
                    SaveScreenshot(pngStream.ToArray());
                }
            }
        }
    }
}
