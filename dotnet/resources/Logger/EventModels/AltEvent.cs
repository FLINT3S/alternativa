namespace Logger.EventModels
{
    public class AltEvent : AltAbstractEvent
    {
        private static readonly object _LockObj = new object();
        
        public AltEvent(object module, string eventName, string eventDescription) : base("logs/events/event.log", module, eventName, eventDescription)
        {
        }

        public override object LockObj => _LockObj;
    }
}