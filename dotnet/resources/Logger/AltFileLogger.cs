using System;
using System.IO;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    public class AltFileLogger : AltLogger
    {
        public override async Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            await using var outputFile = new StreamWriter(serverAltAbstractEvent.Destination, true);
            await outputFile.WriteLineAsync($"{level.ToString().ToUpper()} [{DateTime.Now}]{serverAltAbstractEvent.ToString()}");
        }
    }
}