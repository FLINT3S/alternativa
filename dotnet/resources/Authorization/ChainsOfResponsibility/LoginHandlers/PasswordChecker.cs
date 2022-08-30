using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class PasswordChecker : AbstractLoginHandler
    {
        public PasswordChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractLoginHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) =>
            !account!.IsPasswordsMatch(password);

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            Log(player);
            CefConnect.Trigger(player, LoginEvents.LoginFailure, "Wrong password");
        }

        protected override string EventDescription => "Login failure cause wrong password";
    }
}