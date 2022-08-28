using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class PasswordHandler : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public PasswordHandler(CefConnect cefConnect, AbstractHandler? next) : base(next)
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
                    $"Неверный пароль для пользователя {account.Username}"
                );
        }
    }
}