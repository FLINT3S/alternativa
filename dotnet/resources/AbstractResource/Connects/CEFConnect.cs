using GTANetworkAPI;

namespace AbstractResource.Connects
{
    public class CefConnect : AbstractConnect
    {
        public CefConnect(object module) : base(module)
        {
        }

        protected override string Receiver => "CEF";

        public override void Trigger(Player player, string eventName, params object?[] args)
        {
            string fullEventName = $"{FromTo}:{ModuleName}:{eventName}";
            LogEvent(fullEventName);
            player.TriggerEvent(FromTo, ModuleName, fullEventName, args);
        }

        public void TriggerRaw(Player player, string eventRawString, params object?[] args)
        {
            LogEvent(eventRawString);
            player.TriggerEvent(FromTo, ModuleName, eventRawString, args);
        }

        public override void TriggerMessage(Player player, MessageStatus status, string message, params object[] args)
        {
            string fullEventName = $"{FromTo}:Root:ShowMessage";
            LogEvent(fullEventName);
            player.TriggerEvent(FromTo, ModuleName, fullEventName, args);
        }
    }
}