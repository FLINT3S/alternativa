using System.Threading.Tasks;
using GTANetworkAPI;
using Logger.EventModels;

namespace Logger
{
    public class AltLogger
    {
        private readonly AltConsoleLogger consoleLogger;

        private readonly AltFileLogger fileLogger;

        private AltLogger()
        {
            fileLogger = new AltFileLogger();
            consoleLogger = new AltConsoleLogger();
        }

        public static AltLogger Instance { get; } = new AltLogger();

        #region Methods
        
        public void LogInfo(AltAbstractEvent serverAltAbstractEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogInfo(serverAltAbstractEvent);
            });

        public void LogDevelopment(AltAbstractEvent serverAltAbstractEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogDevelopment(serverAltAbstractEvent);
                await consoleLogger.LogDevelopment(serverAltAbstractEvent);
            });

        public void LogWarning(AltAbstractEvent serverAltAbstractEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogWarning(serverAltAbstractEvent);
                await consoleLogger.LogWarning(serverAltAbstractEvent);
            });

        public void LogCritical(AltAbstractEvent serverAltAbstractEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogCritical(serverAltAbstractEvent);
                await consoleLogger.LogCritical(serverAltAbstractEvent);
            });

        public void LogEvent(AltEvent serverAltEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogEvent(serverAltEvent);
            });

        public void LogResource(AltResourceEvent resourceEvent) => Task.Run(
            async () =>
            {
                await fileLogger.LogResource(resourceEvent);
                await consoleLogger.LogResource(resourceEvent);
            });

        #endregion
    }
}