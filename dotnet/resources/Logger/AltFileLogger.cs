using System;
using System.IO;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    internal class AltFileLogger : AltAbstractLogger
    {
        public override async Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            await using var outputFile = new StreamWriter(serverAltAbstractEvent.Destination, true);
            await outputFile.WriteLineAsync(GetLogString(level, serverAltAbstractEvent));
        }
    }
}