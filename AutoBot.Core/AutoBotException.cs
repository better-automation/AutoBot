using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public class AutoBotException : Exception
    {
        public AutoBotException(string message)
            : base(message)
        {

        }
    }
}
