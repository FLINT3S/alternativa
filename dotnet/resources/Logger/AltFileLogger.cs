using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using Logger.EventModels;

namespace Logger
{
    internal class AltFileLogger : AltAbstractLogger
    {
        private List<string> _logPaths = new List<string>
        {
            "logs",
            "logs/players",
            "logs/resources",
            "logs/events",
        };

        public AltFileLogger()
        {
            if (!_logPaths.All(Directory.Exists))
            {
                Console.WriteLine(GetLogString(LogLevel.Warning,
                    new AltEvent(this, "Logger", "Logger initialized, logs folders not found")));

                foreach (string logPath in _logPaths.Where(logPath => !Directory.Exists(logPath)))
                {
                    Directory.CreateDirectory(logPath);
                    Console.WriteLine(GetLogString(LogLevel.Info,
                        new AltEvent(this, "Logger", $"Logs folder '{logPath}' created")));
                }

                Console.WriteLine(GetLogString(LogLevel.Development,
                    new AltEvent(this, "Logger", "All logs folders created")));
            }
            else
            {
                Console.WriteLine(GetLogString(LogLevel.Development,
                    new AltEvent(this, "Logger", "Logger initialized, all logs folders found")));
            }
        }

        public override async Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            await using var outputFile = new StreamWriter(serverAltAbstractEvent.Destination, true);
            await outputFile.WriteLineAsync(GetLogString(level, serverAltAbstractEvent));
        }
    }
}