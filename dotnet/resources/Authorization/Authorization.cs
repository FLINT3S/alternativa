using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public class Authorization : AltAbstractResource
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            var account = GetAccountFromPlayer(player);

            if (account != null)
            {
                account.OnConnect(player.Address, player.Serial);
                // TODO: Проверить заработает ли дата
                player.SetData("account", account);
            }
            else
            {
                AltLogger.Instance.LogInfo(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                    player.GetPlayerDataString()));
                // TODO: Отправка события на клиент о первом подключении игрока
            }

            // TODO: Проверка на player.Serial == account.LastHWID
        }
        
        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password)
        {
            using var db = new AlternativaContext();
            
            var account = db.Accounts.FirstOrDefault(a => a.Username == login);
            
            if (account == null)
            {
                AltLogger.Instance.LogDevelopment(new AltEvent(this, "OnLoginSubmitFromCef",
                    $"Account not found: {login}"));
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Пользователь {login} не найден");
            }
            else
            {
                if (account.Password == password) CefConnect.TriggerCef(player, AuthorizationEvents.LoginSuccessToCef);
                else CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Неверный пароль для пользователя {login}");
            }
        }
        
        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public void OnRegisterSubmitFromCef(Player player, string login, string password, string email)
        {
            using var db = new AlternativaContext();
            
            var account = new Account(player.SocialClubId, login, password, email);
            
            db.Accounts.Add(account);
            db.SaveChanges();
        }
    }
}