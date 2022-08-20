using System.Linq;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class TemporaryBanChecker : AbstractHandler
    {
        public TemporaryBanChecker(AbstractHandler? next = null) : base(next)
        {
        }
        
        protected override bool CanHandle(Player player) => 
            player.GetAccountFromDb(a => a.TemporaryBans)!.IsTemporaryBanned();

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb(a => a.TemporaryBans)!.GetLongestBan();
            player.TriggerEvent(AuthorizationEvents.TemporaryBanned, ban.Reason, ban.StartDate, ban.EndDate, ban.Description);
        }
    }
}