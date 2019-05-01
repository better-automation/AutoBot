using AutoBot.Core;
using WebBot.Core;
using AutoBot.Web.Navigator.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoBot.Web.Navigator
{
    public class WebNavigator : ISourceNavigator
    {
        private readonly IWebDriver _webDriver;

        private Page[] _pages;
        private Page[] Pages => _pages ?? (_pages = DiscoverPages());

        private string NormalizePageUrl(string pageUrl)
        {
            return new Uri(pageUrl).AbsoluteUri;
        }

        private Page[] DiscoverPages()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes().Where(pageType => pageType.IsClass && !pageType.IsAbstract && pageType.IsSubclassOf(typeof(Page))))
                .Select(pageType => (Page)Activator.CreateInstance(pageType)).ToArray();
        }

        private string NormalizeBrowserUrl(string url)
        {
            return new Uri(url).GetLeftPart(UriPartial.Path);
        }

        public WebNavigator(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public Source GetCurrentSource()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                wait.Until(_ => !IsPageLoading());
            }
            catch (WebDriverTimeoutException)
            {
                throw new PageTookTooLongToLoadException(_webDriver.Url);
            }

            string currentUrl = new Uri(_webDriver.Url).LocalPath;

            Page currentPage = Pages.FirstOrDefault(page => page.Url == currentUrl);

            if (currentPage == null)
            {
                throw new PageNotFoundForUrlException(currentUrl);
            }

            return currentPage;
        }

        public virtual bool IsPageLoading()
        {
            object result = ((IJavaScriptExecutor)_webDriver).ExecuteScript("return document.readyState");

            return !result.Equals("complete");
        }

        public virtual void NavigateToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(_ => !IsPageLoading());
        }
    }
}
