namespace Logger.EventModels
{
    public class AltRpcEvent : AltAbstractEvent
    {
        public AltRpcEvent(string module, string eventName, string eventDescription) : base("logs/events/rpc.log", module, eventName, eventDescription)
        {
        }
    }
}