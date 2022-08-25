namespace Database.Models.AccountEvents
{
    public class ConnectionEvent : AccountEvent
    {
        // EF .ctor
        protected ConnectionEvent()
        {
        }

        public ConnectionEvent(ConnectionEventType type, string ip, string hwid, string? description = null)
            : base(ip, hwid, description) => Type = type;

        public ConnectionEventType Type { get; private set; }
    }
}