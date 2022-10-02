using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class EmailTakenChecker : AbstractRegistrationHandler
    {
        public EmailTakenChecker(ClientConnect clientConnect, CefConnect cefConnect,
            AbstractRegistrationHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Register failure cause user with this email already exist";

        protected override bool CanHandle(Player player, string login, string password, string email) =>
            Account.IsEmailTaken(email);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            Log(player);
            CefConnect.TriggerEvent(
                    player,
                    RegistrationEvents.RegisterFailure,
                    "User with this email already exist"
                );
        }
    }
}