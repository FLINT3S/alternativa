namespace Logger.EventModels
{
    public class AltPlayerEvent : AltAbstractEvent
    {
        public AltPlayerEvent(object playerNickname, object module, string eventName, string eventDescription) : base(
            $"logs/players/{playerNickname}.log", module, eventName, eventDescription)
        {
        }
    }
}