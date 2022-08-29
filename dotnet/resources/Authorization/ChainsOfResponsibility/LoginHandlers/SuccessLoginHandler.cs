using AbstractResource;
using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class SuccessLoginHandler : AbstractHandler
    {
        public SuccessLoginHandler(ClientConnect clientConnect, CefConnect cefConnect) : base(clientConnect, cefConnect, null)
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) => true;

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            account!.UpdateHwid(player.Serial);
            ClientConnect.Trigger(player, AuthorizationEvents.LoginSuccess, "Success!");
            player.SetAccount(account);
        }
    }
}