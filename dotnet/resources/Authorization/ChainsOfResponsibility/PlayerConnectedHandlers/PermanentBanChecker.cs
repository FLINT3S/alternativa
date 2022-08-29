using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class PermanentBanChecker : AbstractHandler
    {
        public PermanentBanChecker(ClientConnect clientConnect, AbstractHandler? next = null) : base(clientConnect, next)
        {
        }

        protected override bool CanHandle(Player player) => player.GetAccountFromDb()?.PermanentBan != null;

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb()!.PermanentBan!;
            ClientConnect.Trigger(player, AuthorizationEvents.PermanentlyBanned, ban.Reason, ban.Description);
        }
    }
}