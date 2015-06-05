using System;

namespace Json2Xml.Core
{
    public static class ConsoleHelper
    {
        public static void DoConsoleErrorColor(Action action)
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                action();
            }
            finally
            {
                Console.ResetColor();
            }
        }

        public static void DoConsoleSuccessColor(Action action)
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                action();
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}