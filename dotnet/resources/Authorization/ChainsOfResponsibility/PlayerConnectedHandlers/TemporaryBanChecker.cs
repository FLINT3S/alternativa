using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    public class TemporaryBanChecker : AbstractHandler
    {
        public TemporaryBanChecker(AbstractHandler? next = null) : base(next)
        {
        }

        protected override bool CanHandle(Player player) =>
            player.GetAccountFromDb()!.IsTemporaryBanned();

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb()!.GetLongestBan();
            player.TriggerEvent(
                    AuthorizationEvents.TemporaryBanned,
                    ban.Reason,
                    ban.StartDate,
                    ban.EndDate,
                    ban.Description
                );
        }
    }
}