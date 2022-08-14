namespace Logger.EventModels
{
    public class AltAccountEvent : AltAbstractEvent
    {
        public AltAccountEvent(object account, string eventName, string eventDescription) : base(
            $"logs/players/{account}.log", account, eventName, eventDescription)
        {
        }
    }
}