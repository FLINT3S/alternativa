using System.Diagnostics.Tracing;
using AbstractResource;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public class Authorization : AltAbstractResource
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            AltLogger.Instance.LogInfo(new AltPlayerEvent(player.Name, this, "Player connected", $"Player {player.Name}[{player.SocialClubId}] connected"));
        }
    }
}