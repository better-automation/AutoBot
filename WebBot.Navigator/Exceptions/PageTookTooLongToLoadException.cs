using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Web.Navigator.Exceptions
{
    public class PageTookTooLongToLoadException : Exception
    {
        public readonly string Url;

        public PageTookTooLongToLoadException(string url)
            : base($"Page took too long to load {url}")
        {
            Url = url;
        }
    }
}
