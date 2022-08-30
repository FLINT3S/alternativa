using AbstractResource.Connects;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class PermanentBanChecker : AbstractConnectionHandler
    {
        public PermanentBanChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(clientConnect, next)
        {
        }

        protected override bool CanHandle(Player player) => player.GetAccountFromDb()?.PermanentBan != null;

        protected override void _Handle(Player player)
        {
            Log(player);
            var ban = player.GetAccountFromDb()!.PermanentBan!;
            ClientConnect.Trigger(player, PlayerConnectedEvents.PermanentlyBanned, ban.Reason, ban.Description);
        }

        protected override string EventDescription => "Connect failure caused Social Club ID permanently banned";
    }
}