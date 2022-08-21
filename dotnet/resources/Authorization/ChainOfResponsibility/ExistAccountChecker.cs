using System.Threading.Tasks;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class ExistAccountChecker : AbstractHandler
    {
        public ExistAccountChecker(AbstractHandler? next = null) : base(next)
        {
        }
        
        protected override async Task<bool> CanHandle(Player player) => !await player.HasAccountInDb();

        protected override async Task _Handle(Player player)
        {
            await AltLogger.Instance.LogInfoAsync(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                player.GetPlayerDataString()));
            player.TriggerEvent(AuthorizationEvents.FirstConnectionToClient);
        }
    }
}