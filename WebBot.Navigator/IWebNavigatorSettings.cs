using WebBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Web.Navigator
{
    public interface IWebNavigatorSettings
    {
        IEnumerable<Page> Pages { get; }
    }
}
