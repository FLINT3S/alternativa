using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public class SuccessLoginHandler : AbstractHandler
    {
        public SuccessLoginHandler(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
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