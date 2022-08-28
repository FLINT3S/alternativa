using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class PasswordChecker : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public PasswordChecker(CefConnect cefConnect, AbstractHandler? next) : base(next)
        {
            this.cefConnect = cefConnect;
        }

        protected override bool CanHandle(Player player, Account account, string login, string password) => 
            !account.IsPasswordsMatch(password);

        protected override void _Handle(Player player, Account account, string login, string password)
        {
            cefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Wrong password"
                );
        }
    }
}