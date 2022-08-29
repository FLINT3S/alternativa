using AbstractResource;
using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class EmailTakenChecker : AbstractHandler
    {
        public EmailTakenChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            Account.IsEmailTaken(email);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "User with this email already exist"
                );
        }
    }
}