using AbstractResource.Connects;
using GTANetworkAPI;
using LocalContext;
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
            player.SetAccount(account);
            account.OnConnect(player.Address, player.Serial);

            #region Character Actions

            // todo вынести весь регион в CharacterManager


            #endregion

            Log(player);
            ClientConnect.Trigger(
                    player,
                    account.IsSameLastHwid(player.Serial) ? PlayerConnectedEvents.LoginSuccess
                        : PlayerConnectedEvents.NeedLogin
                );
        }
    }
}