using System.Linq;
using System.Threading.Tasks;
using Database;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using Microsoft.EntityFrameworkCore;
using NAPIExtensions;

namespace Authorization
{
    public partial class Authorization
    {
        private void NewPlayerActions(Player player)
        {
            AltLogger.Instance.LogInfo(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                player.GetPlayerDataString()));
            player.TriggerEvent(AuthorizationEvents.FirstConnectionToClient);
        }

        private static async Task<bool> IsUsernameTaken(string username) => 
            await AlternativaContext
                .Instance
                .Accounts
                .Select(a => new { a.Username })
                .AnyAsync(a => a.Username == username);
    }
}