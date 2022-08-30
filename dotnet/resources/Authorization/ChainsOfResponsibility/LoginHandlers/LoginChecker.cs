using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

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

        protected override bool CanHandle(Player player, Account? account, string login, string password) =>
            account!.Username != login;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            Log(player);
            CefConnect.Trigger(player, LoginEvents.LoginFailure, "Wrong login");
        }

        protected override string EventDescription => "Login failure cause wrong login";
    }
}