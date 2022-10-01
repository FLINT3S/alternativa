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

        protected override bool CanHandle(Player player) => !AltContext.IsRegisteredPlayer(player);

        protected override void _Handle(Player player)
        {
            var playerEvent = new AltPlayerEvent(
                    this,
                    "Connection",
                    GetConnectionDescription(player)
                );
            AltLogger.Instance.LogInfo(playerEvent);
            ClientConnect.TriggerEvent(player, PlayerConnectedEvents.FirstConnection);
        }

        private static string GetConnectionDescription(Player player)
        {
            string response = "New player connected:\n";
            response += $"Name: {player.Name}\n";
            response += $"SocialClubId: {player.SocialClubId}\n";
            response += $"IP: {player.Address}";
            response += $"HWID: {player.Serial}\n";
            response += $"SocialClubName: {player.SocialClubName}\n";
            response += "===========================================================";
            return response;
        }
    }
}