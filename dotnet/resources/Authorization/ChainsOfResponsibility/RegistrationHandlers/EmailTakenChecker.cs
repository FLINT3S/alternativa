using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class EmailTakenChecker : AbstractHandler
    {
        public EmailTakenChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            Account.IsEmailTaken(email);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "User with this email already exist"
                );
        }
    }
}