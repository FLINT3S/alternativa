using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class TemporaryBanChecker : AbstractHandler
    {
        public TemporaryBanChecker(ClientConnect clientConnect, AbstractHandler? next = null) : base(clientConnect, next)
        {
        }

        protected override bool CanHandle(Player player) =>
            player.GetAccountFromDb()!.IsTemporaryBanned();

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb()!.GetLongestBan();
            ClientConnect.Trigger(
                player, 
                AuthorizationEvents.TemporaryBanned,
                ban.Reason,
                ban.StartDate,
                ban.EndDate,
                ban.Description);
        }
    }
}