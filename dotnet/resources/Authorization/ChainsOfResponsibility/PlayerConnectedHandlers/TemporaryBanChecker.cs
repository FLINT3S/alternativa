using AbstractResource.Connects;
using Database;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class TemporaryBanChecker : AbstractConnectionHandler
    {
        public TemporaryBanChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(
                clientConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Connect failure caused Social Club ID temporary banned";

        protected override bool CanHandle(Player player) => AltContext.GetAccount(player)!.IsTemporaryBanned();

        protected override void _Handle(Player player)
        {
            var ban = AltContext.GetAccount(player)!.GetLongestBan();
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
    }
}