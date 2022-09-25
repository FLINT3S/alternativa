using GTANetworkAPI;
using Logger;
using Logger.EventModels;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource.Connects
{
    public abstract class AbstractConnect
    {
        protected AbstractConnect(object module) => Module = module;

        private object Module { get; }

        protected string ModuleName => Module.GetType().Name;

        protected string FromTo => $"SERVER:{Receiver}";

        protected abstract string Receiver { get; }

        public virtual void Trigger(Player player, string eventName, params object?[] args)
        {
            string fullEventName = $"{FromTo}:{ModuleName}:{eventName}";
            LogEvent(fullEventName);
            player.TriggerEvent(fullEventName, args);
        }

        public virtual void TriggerMessage(Player player, MessageStatus status, string message, params object[] args)
        {
            string fullEventName = $"{FromTo}:Root:ShowMessage";
            LogEvent(fullEventName);
            player.TriggerEvent(fullEventName, status.ToString(), message, args);
        }

        protected void LogEvent(string eventName)
        {
            var altEvent = new AltEvent(Module, eventName, $"{eventName} was send");
            AltLogger.Instance.LogEvent(altEvent);
        }
    }
}