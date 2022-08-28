using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class PasswordChecker : AbstractHandler
    {
        public PasswordChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, Account account, string login, string password) => 
            !account.IsPasswordsMatch(password);

        protected override void _Handle(Player player, Account account, string login, string password)
        {
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Wrong password"
                );
        }
    }
}