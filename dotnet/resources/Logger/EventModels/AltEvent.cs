namespace Logger.EventModels
{
    public class AltEvent : AltAbstractEvent
    {
        public AltEvent(string module, string eventName, string eventDescription) : base("logs/events/event.log", module, eventName, eventDescription)
        {
        }
    }
}