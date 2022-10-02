using AbstractResource.Connects;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class PermanentBanChecker : AbstractConnectionHandler
    {
        public PermanentBanChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(
                clientConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Connect failure caused Social Club ID permanently banned";

        protected override bool CanHandle(Player player) => ((Account)player)?.PermanentBan != null;

        protected override void _Handle(Player player)
        {
            Log(player);
            var ban = ((Account)player)!.PermanentBan!;
            ClientConnect.TriggerEvent(player, PlayerConnectedEvents.PermanentlyBanned, ban.Reason, ban.Description);
        }
    }
}