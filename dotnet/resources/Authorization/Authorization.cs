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
            var account = GetAccountFromPlayer(player);
            
            if (account != null)
            {
                account.OnConnect(player.Address, player.Serial);
                // TODO: Проверить заработает ли дата
                player.SetData("account", account);
            }
            else
            {
                AltLogger.Instance.LogInfo(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                    player.GetPlayerDataString()));
                // TODO: Отправка события на клиент о первом подключении игрока
            }
            
            // TODO: Проверка на player.Serial == account.LastHWID
        }
    }
}