using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class EmailTakenChecker : AbstractHandler
    {
        public EmailTakenChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) =>
            Account.IsEmailTaken(email);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.Trigger(
                    player,
                    RegistrationEvents.RegisterFailure,
                    "User with this email already exist"
                );
        }
    }
}