using System;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger.Loggers
{
    public class AltConsoleLogger : AltLogger
    {
        public override Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent) =>
            Task.Factory.StartNew(() =>
                Console.WriteLine(GetLogString(level, serverAltAbstractEvent)));
    }
}