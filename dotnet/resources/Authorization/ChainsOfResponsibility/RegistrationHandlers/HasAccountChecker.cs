using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class HasAccountChecker : AbstractHandler
    {
        public HasAccountChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            player.HasAccountInDb();

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "User with this Social Club ID already exist"
                );
        }
    }
}