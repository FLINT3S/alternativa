using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class TemporaryBanChecker : AbstractHandler
    {
        public TemporaryBanChecker(AbstractHandler? next = null) : base(next)
        {
        }
        
        protected override async Task<bool> CanHandle(Player player) => 
            (await player.GetAccountFromDb(a => a.TemporaryBans))!.IsTemporaryBanned();

        protected override async Task _Handle(Player player)
        {
            var ban = (await player.GetAccountFromDb(a => a.TemporaryBans))?.GetLongestBan()!;
            player.TriggerEvent(AuthorizationEvents.TemporaryBanned, ban.Reason, ban.StartDate, ban.EndDate, ban.Description);
        }
    }
}