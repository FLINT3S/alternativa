using AbstractResource.Connects;
using Database;
using Database.Models;
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
            player.Transparency = 0;
            var account = (Account)player;
            account.OnConnect(player.Address, player.Serial);
            Log(player);
            player.SetAccessLevels(account.VipLevel, account.AdminLevel);
            ClientConnect.TriggerEvent(player, account.IsSameLastHwid(player.Serial) ? 
                    PlayerConnectedEvents.LoginSuccess : PlayerConnectedEvents.NeedLogin
                );
        }
    }
}