using AutoBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Web.Navigator.Exceptions
{
    public class PageNotFoundForUrlException : AutoBotException
    {
        public readonly string Url;

        public PageNotFoundForUrlException(string url)
            : base($"Page could not be found for url {url}")
        {
            Url = url;
        }
    }
}
