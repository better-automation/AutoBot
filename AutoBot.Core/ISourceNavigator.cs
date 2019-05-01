using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public interface ISourceNavigator
    {
        Source GetCurrentSource();
    }
}
