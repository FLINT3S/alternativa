using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class ExistAccountChecker : AbstractLoginHandler
    {
        public ExistAccountChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractLoginHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) =>
            account == null;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            Log(player);
            CefConnect.Trigger(player, LoginEvents.LoginFailure, "Account not found");
        }

        protected override string EventDescription => "Login failure cause account not found";
    }
}