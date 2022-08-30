using System.Linq;
using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;
using LocalContext;
using Microsoft.EntityFrameworkCore.Internal;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal class DoubleLoginChecker : AbstractLoginHandler
    {
        public DoubleLoginChecker(ClientConnect clientConnect, CefConnect cefConnect, AbstractLoginHandler? next) : base(
                clientConnect,
                cefConnect,
                next
            )
        {
        }

        protected override bool CanHandle(Player player, Account? account, string login, string password) =>
            NAPI.Pools.GetActiveAccounts().ToList().Any(a => a.SocialClubId == player.SocialClubId);

        protected override string EventDescription => "Login failure cause account already online";

        protected override void _Handle(Player player, Account? account, string login, string password)
        {
            Log(player);
            CefConnect.Trigger(player, LoginEvents.LoginFailure, "Account already online");
        }
    }
}