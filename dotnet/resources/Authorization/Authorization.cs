using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;
using PlayerConnectedHandlers = Authorization.ChainsOfResponsibility.PlayerConnectedHandlers;
using RegistrationHandlers = Authorization.ChainsOfResponsibility.RegistrationHandlers;
using LoginHandlers = Authorization.ChainsOfResponsibility.LoginHandler;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public class Authorization : AltAbstractResource
    {
        private readonly PlayerConnectedHandlers.AbstractHandler connectHandlersChain;

        private readonly RegistrationHandlers.AbstractHandler registrationHandlersChain;

        private readonly LoginHandlers.AbstractHandler loginHandlersChain;

        public Authorization()
        {
            connectHandlersChain = GetConnectChain();
            registrationHandlersChain = GetRegistrationChain();
            loginHandlersChain = GetLoginChain();
        }

        #region Chain Builders

        private static PlayerConnectedHandlers.AbstractHandler GetConnectChain()
        {
            var loginStatusSender = new PlayerConnectedHandlers.LoginStatusSender();
            var temporaryBansChecker = new PlayerConnectedHandlers.TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PlayerConnectedHandlers.PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new PlayerConnectedHandlers.ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new PlayerConnectedHandlers.HwidBansChecker(existAccountChecker);
            return hwidBansChecker;
        }

        private RegistrationHandlers.AbstractHandler GetRegistrationChain()
        {
            var successRegistrationHandler = new RegistrationHandlers.SuccessRegistrationHandler(CefConnect, null);
            var usernameTakenHandler = new RegistrationHandlers.UsernameTakenHandler(CefConnect, successRegistrationHandler);
            var hasAccountHandler = new RegistrationHandlers.HasAccountHandler(CefConnect, usernameTakenHandler);
            return hasAccountHandler;
        }

        private LoginHandlers.AbstractHandler GetLoginChain()
        {
            var successLoginHandler = new LoginHandlers.SuccessLoginHandler(CefConnect, null);
            // todo - защита от логина с 2 устройств
            var passwordHandler = new LoginHandlers.PasswordHandler(CefConnect, successLoginHandler);
            var loginHandler = new LoginHandlers.LoginHandler(CefConnect, passwordHandler);
            return loginHandler;
        }

        #endregion

        #region RemoteEvents

        // Здесь ивент от клиента (а не PlayerConnected), о том, что он готов к логину
        // (посылается после загрузки основных браузеров)
        [RemoteEvent(AuthorizationEvents.PlayerReadyFromClient)]
        private void OnPlayerConnectedAndReady(Player player) => connectHandlersChain.Handle(player);

        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password) => 
            loginHandlersChain.Handle(player, player.GetAccountFromDb()!, login, password);

        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public void OnRegisterSubmitFromCef(Player player, string login, string password, string email) =>
            registrationHandlersChain.Handle(player, login, password, email);

        #endregion

        #region Commands
        
        [Command("testacc")]
        public void TestAccount(Player player, string newEmail)
        {
            var account = player.GetAccount();

            if (account == null)
            {
                player.SendChatMessage("Ты не авторизован");
            }
            else
            {
                account.UpdateEmail(newEmail);
                NAPI.Task.Run(
                        () => player.SendChatMessage($"Ты авторизован как {account.Username} with email {account.Email}")
                    );
            }
        }

        [Command("register")]
        public void CMDOnRegister(Player player, string login, string password, string email) => 
            OnRegisterSubmitFromCef(player, login, password, email);

        #endregion
    }
}