using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class DoubleLoginChecker : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public DoubleLoginChecker(CefConnect cefConnect, AbstractHandler? next) : base(next)
        {
            this.cefConnect = cefConnect;
        }

        protected override bool CanHandle(Player player, Account account, string login, string password) => 
            LocalContext.EntityLists.OnlinePlayers.Contains(account);

        protected override void _Handle(Player player, Account account, string login, string password)
        {
            cefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.LoginFailureToCef,
                    "Account already online"
                );
        }
    }
}