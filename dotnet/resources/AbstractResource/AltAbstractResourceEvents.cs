namespace AbstractResource
{
    public abstract class AltAbstractResourceEvents
    {
        public static EventString.EventString GetEs(string eventString) => new EventString.EventString(eventString);
    }
}