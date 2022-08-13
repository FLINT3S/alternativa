using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Logger.EventModels;

namespace Logger
{
    internal class AltFileLogger : AltAbstractLogger
    {
        private readonly List<string> _logPaths = new List<string>
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

        public override Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            lock (serverAltAbstractEvent.LockObj)
                LogSync(level, serverAltAbstractEvent);
            return Task.CompletedTask;
        }

        private static void LogSync(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            using var outputFile = new StreamWriter(serverAltAbstractEvent.Destination, true);
            outputFile.WriteLine(GetLogString(level, serverAltAbstractEvent));   
        }
    }
}