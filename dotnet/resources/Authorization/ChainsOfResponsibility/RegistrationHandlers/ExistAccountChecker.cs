using AbstractResource.Connects;
using Database;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class ExistAccountChecker : AbstractRegistrationHandler
    {
        public ExistAccountChecker(ClientConnect clientConnect, CefConnect cefConnect,
            AbstractRegistrationHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Register failure cause";

        protected override bool CanHandle(Player player, string login, string password, string email) =>
            AltContext.HasAccount(player);

        protected override void _Handle(Player player, string login, string password, string email)
        {
            Log(player);
            CefConnect.Trigger(
                    player,
                    RegistrationEvents.RegisterFailure,
                    "User with this Social Club ID already exist"
                );
        }
    }
}