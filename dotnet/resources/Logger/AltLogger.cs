using System.Threading.Tasks;
using GTANetworkAPI;
using Logger.EventModels;

namespace Logger
{
    public class AltLogger
    {
        private static AltLogger _instance = null!;

        private readonly AltFileLogger fileLogger;

        private readonly AltConsoleLogger consoleLogger;

        public static AltLogger Instance
        {
            get
            {
                _instance ??= new AltLogger();
                return _instance;
            }
        }

        private AltLogger()
        {
            fileLogger = new AltFileLogger();
            consoleLogger = new AltConsoleLogger();
        }

        #region AsyncLogging

        public async Task LogInfoAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogInfo(serverAltAbstractEvent);
        }

        public async Task LogDevelopmentAsync(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogDevelopment(serverAltAbstractEvent);
            await consoleLogger.LogWarning(serverAltAbstractEvent);
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
            NAPI.Task.Run(async () => { await LogInfoAsync(serverAltAbstractEvent); });
        }

        public void LogDevelopment(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(async () => { await LogDevelopmentAsync(serverAltAbstractEvent); });
        }

        public void LogWarning(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(async () => { await LogWarningAsync(serverAltAbstractEvent); });
        }

        public void LogCritical(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(async () => { await LogCriticalAsync(serverAltAbstractEvent); });
        }

        public void LogEvent(AltAbstractEvent serverAltAbstractEvent)
        {
            NAPI.Task.Run(async () => { await LogEventAsync(serverAltAbstractEvent); });
        }

        public void LogResource(AltResourceEvent resourceEvent)
        {
            NAPI.Task.Run(async () => { await LogResourceAsync(resourceEvent); });
        }

        #endregion
    }
}