using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class ExistAccountChecker : AbstractHandler
    {
        public ExistAccountChecker(AbstractHandler? next = null) : base(next)
        {
        }

        protected override bool CanHandle(Player player) => !player.HasAccountInDb();

        protected override void _Handle(Player player)
        {
            AltLogger.Instance.LogInfo(
                    new AltPlayerEvent(
                            "_newPlayers",
                            this,
                            "OnPlayerConnected",
                            player.GetPlayerDataString()
                        )
                );
            player.TriggerEvent(AuthorizationEvents.FirstConnectionToClient);
        }
    }
}