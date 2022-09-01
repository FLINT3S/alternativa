namespace Logger.EventModels
{
    public class AltEvent : AltAbstractEvent
    {
        private static object? _lockObj;

        public AltEvent(object module, string eventName, string eventDescription) :
            base("logs/events/event.log", module, eventName, eventDescription)
        {
        }

        public override object LockObj
        {
            get
            {
                _lockObj ??= new object();
                return _lockObj;
            }
        }
    }
}