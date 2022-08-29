using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class HwidBansChecker : AbstractHandler
    {
        public HwidBansChecker(ClientConnect clientConnect, AbstractHandler? next = null) : base(clientConnect, next)
        {
        }

        protected override bool CanHandle(Player player) => player.GetBanByHwid() != null;

        protected override void _Handle(Player player)
        {
            var hwidBan = player.GetBanByHwid()!;
            ClientConnect.Trigger(player, AuthorizationEvents.PermanentlyBanned, hwidBan.Reason, hwidBan.Description);
        }
    }
}