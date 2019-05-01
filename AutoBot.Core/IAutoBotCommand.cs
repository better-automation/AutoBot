using AutoBot.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoBot.Core
{
    public interface IAutoBotCommand
    {
        void Execute(object component);
    }
}
