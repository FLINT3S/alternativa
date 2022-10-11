using System.Collections.Generic;
using GTANetworkAPI;

namespace AbstractResource.Connects
{
    public class CefConnect : AbstractConnect
    {
        public CefConnect(object module) : base(module)
        {
        }

        protected override string Receiver => "CEF";

        public override void TriggerEvent(Player player, string eventName, params object?[] args)
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

        public void TriggerMessage(Player player, MessageStatus status, string message)
        {
            string fullEventName = $"{FromTo}:Root:ShowMessage";
            LogEvent(fullEventName);
            var paramsList = new List<object> { message, (int)status };
            player.TriggerEvent(FromTo, ModuleName, fullEventName, paramsList);
        }
    }
}