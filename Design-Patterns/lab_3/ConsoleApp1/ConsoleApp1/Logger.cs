using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Logger : ILogger
    {
        private void LogWithColor(string message, ConsoleColor color)
        {
            ConsoleColor colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = colorBefore;
        }

        public void Log(string message)
        {
            LogWithColor(message, ConsoleColor.White);
        }

        public void Error(string errorMessage)
        {
            LogWithColor(errorMessage, ConsoleColor.Red);
        }

        public void Warn(string warnMessage)
        {
            LogWithColor(warnMessage, ConsoleColor.Yellow);
        }
    }
}
