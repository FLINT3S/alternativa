using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class SuccessLoginHandler : AbstractHandler
    {
        private readonly CefConnect cefConnect;

        public SuccessLoginHandler(CefConnect cefConnect, AbstractHandler? next) : base(next)
        {
            this.cefConnect = cefConnect;
        }

        protected override bool CanHandle(Player player, Account account, string login, string password) => true;

        protected override void _Handle(Player player, Account account, string login, string password)
        {
            account.UpdateHwid(player.Serial);
            player.TriggerEvent(AuthorizationEvents.LoginSuccessToClient);
            player.SetAccount(account);
        }
    }
}