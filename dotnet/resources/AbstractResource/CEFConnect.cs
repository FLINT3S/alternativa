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

        public void TriggerCef(Player player, string eventName, params object[] args)
        {
            // moduleName - это имя браузера в который отправится событие.
            // По умолчанию браузер называется так же, как ресурс
            TriggerCefRaw(player, $"SERVER:CEF:{_moduleName}:{eventName}", args);
        }

        public void TriggerCef(Player player, EventString.EventString eventString, params object[] args)
        {
            TriggerCefRaw(player, eventString.ToString(), args);
        }

        public void TriggerCefRaw(Player player, string eventString, params object[] args)
        {
            player.TriggerEvent("SERVER:CEF", _moduleName, eventString, args);
        }
        
        public void TriggerCefRaw(Player player, string browserName, string eventString, params object[] args)
        {
            player.TriggerEvent("SERVER:CEF", browserName, eventString, args);
        }
        
        public void TriggerCefError(Player player, params object[] args)
        {
            player.TriggerEvent("SERVER:CEF", "Root", "ShowErrorMessage", args);
        }
    }
}