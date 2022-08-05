namespace Logger;

public class FileLogger : Logger
{
    public override async Task Log(LogLevel level, EventModel serverEvent)
    {
        await using var outputFile = new StreamWriter(serverEvent.Destination, true);
        await outputFile.WriteLineAsync($"{level.ToString().ToUpper()} [{DateTime.Now}]{serverEvent.ToString()}");
    }
}