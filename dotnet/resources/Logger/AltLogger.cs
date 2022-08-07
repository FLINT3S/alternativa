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
            await fileLogger.Log(LogLevel.Info, serverAltAbstractEvent);
        }

        public async Task LogDevelopment(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.Log(LogLevel.Development, serverAltAbstractEvent);
        }

        public async Task LogWarning(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.Log(LogLevel.Warning, serverAltAbstractEvent);
            await consoleLogger.Log(LogLevel.Warning, serverAltAbstractEvent);
        }

        public async Task LogCritical(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.Log(LogLevel.Critical, serverAltAbstractEvent);
            await consoleLogger.Log(LogLevel.Critical, serverAltAbstractEvent);
        }
        public async Task LogEvent(AltAbstractEvent serverAltAbstractEvent)
        {
            await fileLogger.Log(LogLevel.Event, serverAltAbstractEvent);
        }
    }
}