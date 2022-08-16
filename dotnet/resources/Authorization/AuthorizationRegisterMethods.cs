using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization
{
    public partial class Authorization
    {
        private void NewPlayerActions(Player player)
        {
            AltLogger.Instance.LogInfo(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                player.GetPlayerDataString()));
            CefConnect.TriggerCef(player, AuthorizationEvents.FirstConnectionToCef,
                $"Первое потключение от {player.Name}");
        }
    }
}