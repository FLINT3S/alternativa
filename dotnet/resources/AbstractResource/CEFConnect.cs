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
            TriggerCefRaw(player, $"SERVER:CEF:{_moduleName}:{eventName}", eventData);
        }
        // TODO: Перегрузка TriggerCef для набора (player, eventString, eventData)
        
        public void TriggerCefRaw(Player player, string eventString, object eventData = null)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CEF", _moduleName,
                eventString, NAPI.Util.ToJson(eventData));
        }
    }
}