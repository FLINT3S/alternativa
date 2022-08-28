using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class UsernameTakenChecker : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public UsernameTakenChecker(CefConnect cefConnect, AbstractHandler? next) : base(next)
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
                    "User with this login already exist"
                );
        }
    }
}