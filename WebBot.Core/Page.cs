using AutoBot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.Core
{
    public abstract class Page : Source
    {
        public abstract string Url { get; }
    }
}
