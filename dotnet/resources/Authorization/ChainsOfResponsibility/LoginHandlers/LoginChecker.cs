using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    public class LoginChecker : AbstractHandler
    {
        public LoginChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) => 
            account!.Username != login;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Wrong login"
                );
        }
    }
}