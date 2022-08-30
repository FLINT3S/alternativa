using System;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    internal class AltConsoleLogger : AltAbstractLogger
    {
        protected override void Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            SetConsoleColor(level);
            Console.WriteLine(GetLogString(level, serverAltAbstractEvent));
            Console.ResetColor();
        }

        private static void SetConsoleColor(LogLevel level)
        {
            Console.ForegroundColor = level switch
            {
                LogLevel.Critical => ConsoleColor.Red,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Development => ConsoleColor.Blue,
                LogLevel.Resource => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
        }
    }
}