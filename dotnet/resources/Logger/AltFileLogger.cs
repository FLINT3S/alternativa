using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Logger.EventModels;

namespace Logger
{
    internal class AltFileLogger : AltAbstractLogger
    {
        public AltFileLogger()
        {
            var logPaths = new List<string>
            {
                "logs",
                "logs/players",
                "logs/resources",
                "logs/events"
            };

            if (!logPaths.All(Directory.Exists))
            {
                Console.WriteLine(
                        GetLogString(
                                LogLevel.Warning,
                                new AltEvent(this, "Logger", "Logger initialized, logs folders not found")
                            )
                    );

                foreach (string logPath in logPaths.Where(logPath => !Directory.Exists(logPath)))
                {
                    Directory.CreateDirectory(logPath);
                    Console.WriteLine(
                            GetLogString(
                                    LogLevel.Info,
                                    new AltEvent(this, "Logger", $"Logs folder '{logPath}' created")
                                )
                        );
                }

                Console.WriteLine(
                        GetLogString(
                                LogLevel.Development,
                                new AltEvent(this, "Logger", "All logs folders created")
                            )
                    );
            }
            else
            {
                Console.WriteLine(
                        GetLogString(
                                LogLevel.Development,
                                new AltEvent(this, "Logger", "Logger initialized, all logs folders found")
                            )
                    );
            }
        }

        protected override void Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent)
        {
            lock (serverAltAbstractEvent.LockObj)
            {
                using var outputFile = new StreamWriter(serverAltAbstractEvent.Destination, true);
                outputFile.WriteLine(GetLogString(level, serverAltAbstractEvent));
            }
        }
    }
}