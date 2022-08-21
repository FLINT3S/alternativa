using System.Threading.Tasks;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class PermanentBanChecker : AbstractHandler
    {
        public PermanentBanChecker(AbstractHandler? next = null) : base(next)
        {
        }
        
        protected override async Task<bool> CanHandle(Player player) => (await player.GetAccountFromDb())!.PermanentBan != null;

        protected override async Task _Handle(Player player)
        {
            var ban = (await player.GetAccountFromDb())?.PermanentBan!;
            player.TriggerEvent(AuthorizationEvents.PermanentlyBanned, ban.Reason, ban.Description);
        }
    }
}