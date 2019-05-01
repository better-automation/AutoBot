using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBot.Core
{
    public interface IAutoBotQuery<TResult>
    {
        TResult Run(object component);
    }
}
