using AbstractResource;
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
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Account already online"
                );
        }
    }
}