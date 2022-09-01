using System.Diagnostics.CodeAnalysis;

namespace Database.Models.AccountEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class ConnectionEvent : AccountEvent
    {
        // EF .ctor
        // ReSharper disable once UnusedMember.Global
        protected ConnectionEvent()
        {
        }

        public ConnectionEvent(ConnectionEventType type, string ip, string hwid, string description = null)
            : base(ip, hwid, description) => Type = type;

        public ConnectionEventType Type { get; private set; }
    }
}