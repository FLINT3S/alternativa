using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class SuccessLoginHandler : AbstractLoginHandler
    {
        public SuccessLoginHandler(ClientConnect clientConnect, CefConnect cefConnect) : base(
                clientConnect,
                cefConnect,
                null
            )
        {
        }

        protected override string EventName => "LoginSuccess";

        protected override string EventDescription => "Login success";

        protected override bool CanHandle(Player player, Account? account, string login, string password) => true;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            account!.UpdateHwid(player.Serial);
            ClientConnect.Trigger(player, LoginEvents.LoginSuccess, "Success!");
            Log(player);
        }
    }
}