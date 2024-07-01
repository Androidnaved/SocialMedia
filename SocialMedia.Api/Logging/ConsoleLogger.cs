using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Api.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"ERROR: {message}\nException: {ex}");
        }
    }
}
