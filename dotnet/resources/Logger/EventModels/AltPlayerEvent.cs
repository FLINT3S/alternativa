namespace Logger.EventModels
{
    public class AltPlayerEvent : AltAbstractEvent
    {
        public AltPlayerEvent(object player, object module, string eventName, string eventDescription) : base(
            $"logs/players/{player}.log", module, eventName, eventDescription)
        {
        }
    }
}