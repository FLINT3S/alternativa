using System;
using System.Threading.Tasks;
using Logger.EventModels;

/*
 * Wiki: https://www.notion.so/Logger-736d00518e2f4599997fdfa501310ec9
 */


namespace Logger
{
    internal abstract class AltAbstractLogger
    {
        protected static string GetLogString(LogLevel level, AltAbstractEvent serverAltAbstractEvent) =>
            $"{level.ToString().ToUpper()} [{DateTime.Now:dd.MM.yyyy HH:mm:ss}] {serverAltAbstractEvent}";

        protected abstract void Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent);

        public void LogInfo(AltAbstractEvent serverAltAbstractEvent) => Log(LogLevel.Info, serverAltAbstractEvent);

        public void LogDevelopment(AltAbstractEvent serverAltAbstractEvent) => Log(LogLevel.Development, serverAltAbstractEvent);

        public void LogWarning(AltAbstractEvent serverAltAbstractEvent) => Log(LogLevel.Warning, serverAltAbstractEvent);

        public void LogCritical(AltAbstractEvent serverAltAbstractEvent) => Log(LogLevel.Critical, serverAltAbstractEvent);

        public void LogEvent(AltEvent serverAltEvent) => Log(LogLevel.Event, serverAltEvent);

        public void LogResource(AltAbstractEvent serverAltAbstractEvent) => Log(LogLevel.Resource, serverAltAbstractEvent);
    }
}