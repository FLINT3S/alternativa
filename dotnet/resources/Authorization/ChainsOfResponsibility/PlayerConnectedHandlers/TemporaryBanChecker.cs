using AbstractResource.Connects;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class TemporaryBanChecker : AbstractConnectionHandler
    {
        public TemporaryBanChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(clientConnect, next)
        {
        }

        protected override bool CanHandle(Player player) =>
            player.GetAccountFromDb()!.IsTemporaryBanned();

        protected override void _Handle(Player player)
        {
            var ban = player.GetAccountFromDb()!.GetLongestBan();
            Log(player);
            ClientConnect.Trigger(
                    player,
                    PlayerConnectedEvents.TemporaryBanned,
                    ban.Reason,
                    ban.StartDate,
                    ban.EndDate,
                    ban.Description
                );
        }

        protected override string EventDescription => "Connect failure caused Social Club ID temporary banned";
    }
}