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
        
        public abstract Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent);

        public async Task LogInfo(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Info, serverAltAbstractEvent);

        public async Task LogDevelopment(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Development, serverAltAbstractEvent);

        public async Task LogWarning(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Warning, serverAltAbstractEvent);

        public async Task LogCritical(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Critical, serverAltAbstractEvent);

        public async Task LogEvent(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Event, serverAltAbstractEvent);
        
        public async Task LogResource(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Resource, serverAltAbstractEvent);
    }
}