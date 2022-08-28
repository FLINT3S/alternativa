using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class UsernameTakenHandler : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public UsernameTakenHandler(CefConnect cefConnect, AbstractHandler? next) : base(next)
        {
            this.cefConnect = cefConnect;
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            Account.IsUsernameTaken(login);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            cefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "Пользователь с таким логином зарегистрирован"
                );
        }
    }
}