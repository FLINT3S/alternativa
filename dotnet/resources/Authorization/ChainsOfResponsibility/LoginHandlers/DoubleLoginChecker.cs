using AbstractResource;
using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class DoubleLoginChecker : AbstractHandler
    {
        public DoubleLoginChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) => 
            LocalContext.EntityLists.OnlinePlayers.Contains(account);

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Account already online"
                );
        }
    }
}