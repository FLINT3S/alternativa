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
            if (account == null)
            {
                NewPlayerActions(player);
                return;
            }

            account.OnConnect(player.Address, player.Serial);
            // TODO: Проверить заработает ли дата
            player.SetData("account", account);
            // TODO: Проверка на player.Serial == account.LastHWID
        }

        private void NewPlayerActions(Player player)
        {
            AltLogger.Instance.LogInfo(new AltPlayerEvent("_newPlayers", this, "OnPlayerConnected",
                player.GetPlayerDataString()));
            CefConnect.TriggerCef(player, AuthorizationEvents.FirstConnectionToCef, $"Первое потключение от {player.Name}");
            // TODO: Проверить правильность отправки события первого подключения
        }
        
        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password)
        {
            using var db = new AlternativaContext();
            
            var account = db.Accounts.FirstOrDefault(a => a.Username == login);

            if (account != null)
                AccountFoundActions(player, account, password);
            else
                AccountNotFoundActions(player, login);
        }

        private void AccountFoundActions(Player player, Account account, string password)
        {
            if (account.Password == password)
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginSuccessToCef);
            else
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Неверный пароль для пользователя {account.Username}");
        }

        private void AccountNotFoundActions(Player player, string login)
        {
            AltLogger.Instance.LogDevelopment(new AltEvent(this, "OnLoginSubmitFromCef", $"Account not found: {login}"));
            CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Пользователь {login} не найден");
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