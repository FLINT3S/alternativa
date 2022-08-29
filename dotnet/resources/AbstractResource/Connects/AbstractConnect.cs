using System;
using GTANetworkAPI;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource.Connects
{
    public abstract class AbstractConnect
    {
        protected AbstractConnect(object module) => ModuleName = module.GetType().Name;

        protected string ModuleName { get; }
        
        protected string FromTo => $"SERVER:{Receiver}";

        protected abstract string Receiver { get; }

        public virtual void Trigger(Player player, string eventName, params object?[] args)
        {
            player.TriggerEvent($"{FromTo}:{ModuleName}:{eventName}", args);
        }

        protected void TriggerMessage(Player player, MessageStatus status, string message, params object[] args)
        {
            player.TriggerEvent($"{FromTo}:Root:ShowErrorMessage", status.ToString(), message, args);
        }
    }
}