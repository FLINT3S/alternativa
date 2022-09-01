using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class LoginStatusSender : AbstractConnectionHandler
    {
        public LoginStatusSender(ClientConnect clientConnect) : base(clientConnect, null)
        {
        }

        protected override string EventName => "ConnectSuccess";

        protected override string EventDescription => "Connect success";

        protected override bool CanHandle(Player player) => true;

        protected override void _Handle(Player player)
        {
            var account = player.GetAccountFromDb()!;
            account.OnConnect(player.Address, player.Serial);

            Log(player);
            ClientConnect.Trigger(
                    player,
                    account.IsSameLastHwid(player.Serial) ? PlayerConnectedEvents.LoginSuccess
                        : PlayerConnectedEvents.NeedLogin
                );
        }
    }
}