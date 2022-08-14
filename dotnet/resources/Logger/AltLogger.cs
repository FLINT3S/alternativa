using System.Threading.Tasks;
using GTANetworkAPI;
using Logger.EventModels;

namespace Logger
{
    public class AltLogger
    {
        private static AltLogger _instance = null!;

        private readonly AltConsoleLogger consoleLogger;

        private readonly AltFileLogger fileLogger;

        private AltLogger()
        {
            fileLogger = new AltFileLogger();
            consoleLogger = new AltConsoleLogger();
        }

        public static AltLogger Instance
        {
            get
            {
                _instance ??= new AltLogger();
                return _instance;
            }
        }

        #region AsyncLogging
        public async Task LogInfoAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogInfo(serverAltAbstractEvent);
        }

        public async Task LogDevelopmentAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogDevelopment(serverAltAbstractEvent);
            await consoleLogger.LogDevelopment(serverAltAbstractEvent);
        }

        public async Task LogWarningAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogWarning(serverAltAbstractEvent);
            await consoleLogger.LogWarning(serverAltAbstractEvent);
        }

        public async Task LogCriticalAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogCritical(serverAltAbstractEvent);
            await consoleLogger.LogCritical(serverAltAbstractEvent);
        }

        public async Task LogEventAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogEvent(serverAltAbstractEvent);
        }

        public async Task LogResourceAsync(AltResourceEvent resourceEvent)
        {
            await fileLogger.LogResource(resourceEvent);
            await consoleLogger.LogResource(resourceEvent);
        }
        #endregion

        #region SyncLogging
        public void LogInfo(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(() => { LogInfoAsync(serverAltAbstractEvent); });
        }

        public void LogDevelopment(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(() => { LogDevelopmentAsync(serverAltAbstractEvent); });
        }

        public void LogWarning(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(() => { LogWarningAsync(serverAltAbstractEvent); });
        }

        public void LogCritical(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(() => { LogCriticalAsync(serverAltAbstractEvent); });
        }

        public void LogEvent(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(() => { LogEventAsync(serverAltAbstractEvent); });
        }

        public void LogResource(AltResourceEvent resourceEvent)
        {
            NAPI.Task.Run(() => { LogResourceAsync(resourceEvent); });
        }
        #endregion
    }
}