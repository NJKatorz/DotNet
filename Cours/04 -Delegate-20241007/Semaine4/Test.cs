using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine4
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            // Register a custom logging method
            logger.Log += ConsoleLogger.LogMessage;
            // Register a logging in a file method
            logger.Log += FileLogger.LogMessage;

            // Log a message
            logger.LogMessage("This is a custom log message.");
            logger.LogMessage("This is a second custom log message");
        }

    }
}
