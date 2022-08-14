namespace Logger.EventModels
{
    public class AltAccountEvent : AltAbstractEvent
    {
        public AltAccountEvent(ulong socialClubId, object module, string eventName, string eventDescription) : base(
            $"logs/players/{socialClubId}.log", module, eventName, eventDescription)
        {
        }
    }
}