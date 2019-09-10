using System;
using System.Collections.Generic;
using System.Text;

namespace Concurrent
{
    public class ConsoleHelper
    {
        public static class ColoredConsole
        {
            private static object syncOutput = new object();

            public static void WirteLine(string message)
            {
                lock (syncOutput)
                {
                    Console.WriteLine(message);
                }
            }

            public static void WirteLine(string message, string color)
            {
                lock (syncOutput)
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
                    Console.WriteLine(message);
                    Console.ResetColor();
                }
            }
        }
    }
}
