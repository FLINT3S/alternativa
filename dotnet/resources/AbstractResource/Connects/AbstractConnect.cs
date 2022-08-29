using GTANetworkAPI;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource.Connects
{
    public abstract class AbstractConnect
    {
        protected AbstractConnect(object module) => ModuleName = module.GetType().Name;

        private string ModuleName { get; }

        protected abstract string Receiver { get; }

        public void Trigger(Player player, string eventName, params object[] args)
        {
            // moduleName - это имя браузера в который отправится событие.
            // По умолчанию браузер называется так же, как ресурс
            TriggerRaw(player, $"SERVER:{Receiver}:{ModuleName}:{eventName}", args);
        }

        public void Trigger(Player player, EventString eventString, params object[] args)
        {
            TriggerRaw(player, eventString.ToString(), args);
        }

        public void TriggerRaw(Player player, string eventString, params object[] args)
        {
            player.TriggerEvent($"SERVER:{Receiver}", ModuleName, eventString, args);
        }

        public void TriggerRaw(Player player, string browserName, string eventString, params object[] args)
        {
            player.TriggerEvent($"SERVER:{Receiver}", browserName, eventString, args);
        }

        public void TriggerMessage(Player player, MessageStatus status, string message, params object[] args)
        {
            player.TriggerEvent($"SERVER:{Receiver}", "Root", "ShowErrorMessage", status.ToString(), message, args);
        }
    }
}