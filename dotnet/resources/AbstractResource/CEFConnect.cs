using GTANetworkAPI;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

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
            // moduleName - это имя браузера в который отправится событие.
            // По умолчанию браузер называется так же, как ресурс
            TriggerCefRaw(player, $"SERVER:CEF:{_moduleName}:{eventName}", eventData);
        }

        public void TriggerCef(Player player, EventString.EventString eventString, string eventData)
        {
            TriggerCefRaw(player, eventString.ToString(), eventData);
        }

        public void TriggerCefRaw(Player player, string eventString, object eventData = null)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CEF", _moduleName,
                eventString, NAPI.Util.ToJson(eventData));
        }
    }
}