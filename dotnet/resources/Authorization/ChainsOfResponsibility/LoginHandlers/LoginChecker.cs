using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class LoginChecker : AbstractLoginHandler
    {
        public LoginChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractLoginHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Login failure cause wrong login";

        protected override bool CanHandle(Player player, Account? account, string login, string password) =>
            account!.Username != login;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            Log(player);
            CefConnect.TriggerEvent(player, LoginEvents.LoginFailure, "Wrong login");
        }
    }
}