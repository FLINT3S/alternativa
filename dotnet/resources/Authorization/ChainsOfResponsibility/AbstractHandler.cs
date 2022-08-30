using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility
{
    internal abstract class AbstractHandler
    {
        protected abstract string EventName { get; }
        
        protected abstract string EventDescription { get; }

        protected void Log(Player player)
        {
            var playerEvent = GetEvent(player);
            AltLogger.Instance.LogInfo(playerEvent);
        }

        private AltPlayerEvent GetEvent(Player player) => 
            new AltPlayerEvent(player.GetString()!, this, EventName, EventDescription);
    }
}