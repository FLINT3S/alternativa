using System.Threading.Tasks;
using AbstractResource;
using Authorization.ChainOfResponsibility;
using Database;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public partial class Authorization : AltAbstractResource
    {
        private readonly AbstractHandler connectHandler;

        public Authorization()
        {
            var loginStatusSender = new LoginStatusSender();
            var temporaryBansChecker = new TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new HwidBansChecker(existAccountChecker);
            connectHandler = hwidBansChecker;
        }
        
        // Здесь ивент от клиента (а не PlayerConnected), о том, что он готов к логину
        // (посылается после загрузки основных браузеров)
        [RemoteEvent(AuthorizationEvents.PlayerReadyFromClient)]
        private void OnPlayerConnectedAndReady(Player player) => connectHandler.Handle(player);

        #region RemoteEvents

        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password)
        {
            var account = player.GetAccountFromDb()!; // todo
            if (account.Username != login)
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef,
                    "Неверный логин");
            else if (!account.IsPasswordsMatch(password))
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef,
                    $"Неверный пароль для пользователя {account.Username}");
            // todo - защита от логина с 2 устройств
            else
                SuccessLoginActions(player, account);
        }

        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public Task OnRegisterSubmitFromCef(Player player, string login, string password, string email)
        {
            if (player.HasAccountInDb())
                CefConnect.TriggerCef(player, AuthorizationEvents.RegisterFailureToCef,
                    "Пользователь с таким Soсial Club уже зарегистрирован");
            else if (IsUsernameTaken(login))
                CefConnect.TriggerCef(player, AuthorizationEvents.RegisterFailureToCef,
                    "Пользователь с таким логином");
            else
            {
                // AltLogger.Instance.LogInfoAsync(new AltAccountEvent(this, "Set Username", ""));
                var account = new Account(player.SocialClubId, login, password, email);
                account.AddToContext();
                CefConnect.TriggerCef(player, AuthorizationEvents.RegisterSuccessToClient, "Успех!");
            }

            return Task.CompletedTask;
        }

        #endregion

        [Command("testacc")]
        public void TestAccount(Player player, string newEmail)
        {
            var account = player.GetAccount();

            if (account == null)
                player.SendChatMessage("Ты не авторизован");
            else
            {
                account.UpdateEmail(newEmail);
                NAPI.Task.Run(() => player.SendChatMessage($"Ты авторизован как {account.Username} with email {account.Email}"));
            }
        }
    }
}