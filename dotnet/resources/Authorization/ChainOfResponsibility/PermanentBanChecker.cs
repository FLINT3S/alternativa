using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class PermanentBanChecker : AbstractHandler
    {
        public PermanentBanChecker(AbstractHandler? next = null) : base(next)
        {
        }

        protected override bool CanHandle(Player player) => player.GetAccountFromDb()?.PermanentBan != null;

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb()!.PermanentBan!;
            player.TriggerEvent(AuthorizationEvents.PermanentlyBanned, ban.Reason, ban.Description);
        }
    }
}