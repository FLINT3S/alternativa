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
        
        public void LogInfo(AltAbstractEvent serverAltAbstractEvent)
        {
            fileLogger.LogInfo(serverAltAbstractEvent);
        }

        public void LogDevelopment(AltAbstractEvent serverAltAbstractEvent)
        {
            fileLogger.LogDevelopment(serverAltAbstractEvent);
            consoleLogger.LogDevelopment(serverAltAbstractEvent);
        }

        public void LogWarning(AltAbstractEvent serverAltAbstractEvent)
        {
            fileLogger.LogWarning(serverAltAbstractEvent);
            consoleLogger.LogWarning(serverAltAbstractEvent);
        }

        public void LogCritical(AltAbstractEvent serverAltAbstractEvent)
        {
            fileLogger.LogCritical(serverAltAbstractEvent);
            consoleLogger.LogCritical(serverAltAbstractEvent);
        }

        public void LogEvent(AltEvent serverAltEvent)
        {
            consoleLogger.LogEvent(serverAltEvent);
            fileLogger.LogEvent(serverAltEvent);
        }

        public void LogResource(AltResourceEvent resourceEvent)
        {
            fileLogger.LogResource(resourceEvent);
            consoleLogger.LogResource(resourceEvent);
        }
        
        #endregion
    }
}