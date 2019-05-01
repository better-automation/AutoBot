using System;
using System.Collections.Generic;
using System.Text;

namespace WebBot.WebDrivers.Exceptions
{
    public class TargetPlatformNotSupportedException : Exception
    {
        public readonly string TargetPlatformName;

        public TargetPlatformNotSupportedException(string targetPlatformName)
            : base($"No supported platform found for {targetPlatformName}")
        {
            TargetPlatformName = targetPlatformName;
        }
    }
}
