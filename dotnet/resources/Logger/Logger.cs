namespace Logger;

public class Logger
{
    public static async Task Log(LogLevel level, EventModel serverEvent)
    {
        await using var outputFile = new StreamWriter(serverEvent.Destination, true);
        await outputFile.WriteLineAsync($"{level.ToString().ToUpper()} [{DateTime.Now}]{serverEvent.ToString()}");
    }

    public static async Task LogInfo(EventModel serverEvent) => await Log(LogLevel.Info, serverEvent);

    public static async Task LogDevelopment(EventModel serverEvent) => await Log(LogLevel.Development, serverEvent);

    public static async Task LogWarning(EventModel serverEvent) => await Log(LogLevel.Warning, serverEvent);

    public static async Task LogCritical(EventModel serverEvent) => await Log(LogLevel.Critical, serverEvent);
}