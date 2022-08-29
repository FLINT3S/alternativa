using AbstractResource;
using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class SuccessRegistrationHandler : AbstractHandler
    {
        public SuccessRegistrationHandler(CefConnect cefConnect) : base(cefConnect, null)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => true;
        
        protected override void _Handle(Player player, string login, string password, string email)
        {
            var account = new Account(player.SocialClubId, login, password, email);
            account.AddToContext();
            player.TriggerEvent(AuthorizationEvents.RegisterSuccessToClient);
            // CefConnect.TriggerCef(player, AuthorizationEvents.RegisterSuccessToClient, "Success!");
        }
    }
}