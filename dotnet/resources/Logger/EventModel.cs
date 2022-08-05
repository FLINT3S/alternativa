namespace Logger;

public abstract class EventModel
{
    protected EventModel(string destination, string module, string eventName, string eventDescription)
    {
        Destination = destination;
        Module = module;
        EventName = eventName;
        EventDescription = eventDescription;
    }

    public string Destination { get; }

    private string Module { get; }

    protected virtual string EventInstance => GetType().FullName!;

    private string EventName { get; }

    private string EventDescription { get; }

    public override string ToString() => $"{EventInstance}: {Module} > {EventName} - {EventDescription}";
}