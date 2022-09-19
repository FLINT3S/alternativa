using AbstractResource.Connects;
using Database;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class ExistAccountChecker : AbstractConnectionHandler
    {
        public ExistAccountChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(
                clientConnect,
                next
            )
        {
        }

        protected override string EventDescription => "";

        protected override bool CanHandle(Player player) => !AltContext.HasAccount(player);

        protected override void _Handle(Player player)
        {
            var playerEvent = new AltPlayerEvent(
                    "_newPlayers",
                    this,
                    "Connection",
                    player.GetPlayerConnectedDataString()
                );
            AltLogger.Instance.LogInfo(playerEvent);
            ClientConnect.Trigger(player, PlayerConnectedEvents.FirstConnection);
        }
    }
}