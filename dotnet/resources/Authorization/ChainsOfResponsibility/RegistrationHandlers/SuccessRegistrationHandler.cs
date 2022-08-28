﻿using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class SuccessRegistrationHandler : AbstractHandler
    {
        public SuccessRegistrationHandler(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => true;
        
        protected override void _Handle(Player player, string login, string password, string email)
        {
            var account = new Account(player.SocialClubId, login, password, email);
            account.AddToContext();
            CefConnect.TriggerCef(player, AuthorizationEvents.RegisterSuccessToClient, "Success!");
        }
    }
}