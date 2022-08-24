using System.Linq;
using Database;
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
            AltLogger.Instance.LogInfo(
                    new AltPlayerEvent(
                            "_newPlayers",
                            this,
                            "OnPlayerConnected",
                            player.GetPlayerDataString()
                        )
                );
            player.TriggerEvent(AuthorizationEvents.FirstConnectionToClient);
        }

        private static bool IsUsernameTaken(string username) => 
            AltDb.Context.Accounts.Select(a => new { a.Username }).Any(a => a.Username == username);
    }
}