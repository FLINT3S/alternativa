using System.Threading.Tasks;
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
            get {
                _instance ??= new AltLogger();
                return _instance;
            }
        }

        private AltLogger()
        {
            fileLogger = new AltFileLogger();
            consoleLogger = new AltConsoleLogger();
        }

        public async Task LogInfo(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogInfo(serverAltAbstractEvent);
        }

        public async Task LogDevelopment(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogDevelopment(serverAltAbstractEvent);
        }

        public async Task LogWarning(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogWarning(serverAltAbstractEvent);
            await consoleLogger.LogWarning(serverAltAbstractEvent);
        }

        public async Task LogCritical(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogCritical(serverAltAbstractEvent);
            await consoleLogger.LogCritical(serverAltAbstractEvent);
        }
        public async Task LogEvent(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.LogEvent(serverAltAbstractEvent);
        }
    }
}