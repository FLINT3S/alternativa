using AbstractResource;
using GTANetworkAPI;

namespace AbstractResource
{
    public class CefConnect
    {
        private readonly string _moduleName;

        public CefConnect(object module)
        {
            _moduleName = module.GetType().Name;
        }

        public void TriggerCef(Player player, string eventName, object eventData = null)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CEF", _moduleName,
                $"SERVER:CEF:{_moduleName}:{eventName}", NAPI.Util.ToJson(eventData));
        }
    }
}