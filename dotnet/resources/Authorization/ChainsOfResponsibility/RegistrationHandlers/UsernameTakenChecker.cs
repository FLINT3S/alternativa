using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class UsernameTakenChecker : AbstractHandler
    {
        public UsernameTakenChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) =>
            Account.IsUsernameTaken(login);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.RegisterFailure,
                    "User with this login already exist"
                );
        }
    }
}