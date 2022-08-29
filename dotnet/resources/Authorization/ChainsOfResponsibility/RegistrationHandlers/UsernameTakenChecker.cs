using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class UsernameTakenChecker : AbstractHandler
    {
        public UsernameTakenChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            Account.IsUsernameTaken(login);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "User with this login already exist"
                );
        }
    }
}