namespace Logger;

/*
 * Wiki: https://www.notion.so/Logger-736d00518e2f4599997fdfa501310ec9
 */

public abstract class Logger
{
    public abstract Task Log(LogLevel level, EventModel serverEvent);

    public async Task LogInfo(EventModel serverEvent) => await Log(LogLevel.Info, serverEvent);

    public async Task LogDevelopment(EventModel serverEvent) => await Log(LogLevel.Development, serverEvent);

    public async Task LogWarning(EventModel serverEvent) => await Log(LogLevel.Warning, serverEvent);

    public async Task LogCritical(EventModel serverEvent) => await Log(LogLevel.Critical, serverEvent);
}