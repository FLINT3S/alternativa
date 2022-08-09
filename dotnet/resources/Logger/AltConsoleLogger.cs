using System;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    internal class AltConsoleLogger : AltAbstractLogger
    {
        public override Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent) =>
            Task.Factory.StartNew(() =>
                {
                    SetConsoleColor(level);
                    Console.WriteLine(GetLogString(level, serverAltAbstractEvent));
                    SetConsoleColor(LogLevel.Info);
                }
            );

        public void SetConsoleColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Development:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogLevel.Resource:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}