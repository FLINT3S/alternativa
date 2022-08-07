using System;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    internal class AltConsoleLogger : AltAbstractLogger
    {
        public override Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent) =>
            Task.Factory.StartNew(() =>
                Console.WriteLine(GetLogString(level, serverAltAbstractEvent)));
    }
}