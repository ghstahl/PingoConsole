using System;

namespace Pingo.CommandLine.ConsoleUtility
{
    public static class ConsoleHelper
    {
        private enum ConsoleColorRotation
        {
            DarkYellow = ConsoleColor.DarkYellow,
            Blue = ConsoleColor.Blue,
            Green = ConsoleColor.Green,
            Cyan = ConsoleColor.Cyan,
            Red = ConsoleColor.Red,
            Magenta = ConsoleColor.Magenta,
            Yellow = ConsoleColor.Yellow,
            White = ConsoleColor.White,
        }

        private static int _currentRotationIndex = 0;
        private static Array _consoleColorRotationArray;
        private static Array ConsoleColorRotationArray
        {
            get
            {
                return _consoleColorRotationArray ??
                       (_consoleColorRotationArray = Enum.GetValues(typeof(ConsoleColorRotation)));
            }
        }

        private static ConsoleColor NextColor
        {
            get
            {
                var result = ConsoleColorRotationArray.GetValue(_currentRotationIndex);
                ++_currentRotationIndex;
                if (_currentRotationIndex >= ConsoleColorRotationArray.Length)
                {
                    _currentRotationIndex = 0;
                }
                return (ConsoleColor)result;
            }
        }

        public static void DoConsoleForeGroudRotation(Action action)
        {
            try
            {
                Console.ForegroundColor = NextColor;
                action();
            }
            finally
            {
                Console.ResetColor();
            }
        }

        public static void DoConsoleErrorColor(Action action)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
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