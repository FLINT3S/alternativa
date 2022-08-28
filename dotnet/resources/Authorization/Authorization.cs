using AbstractResource;
using Authorization.ChainsOfResponsibility;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;
using PlayerConnectedHandlers = Authorization.ChainsOfResponsibility.PlayerConnectedHandlers;
using RegistrationHandlers = Authorization.ChainsOfResponsibility.RegistrationHandlers;
using LoginHandlers = Authorization.ChainsOfResponsibility.LoginHandlers;

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
            connectHandlersChain = ChainsFactory.GetConnectChain();
            registrationHandlersChain = ChainsFactory.GetRegistrationChain(CefConnect);
            loginHandlersChain = ChainsFactory.GetLoginChain(CefConnect);
        }

        #region RemoteEvents

        // Здесь ивент от клиента (а не PlayerConnected), о том, что он готов к логину
        // (посылается после загрузки основных браузеров)
        [RemoteEvent(AuthorizationEvents.PlayerReadyFromClient)]
        private void OnPlayerConnectedAndReady(Player player) => 
            connectHandlersChain.Handle(player);

        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password) => 
            loginHandlersChain.Handle(player, player.GetAccountFromDb(), login, password);

        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public void OnRegisterSubmitFromCef(Player player, string login, string password, string email) =>
            registrationHandlersChain.Handle(player, login, password, email);

        [RemoteEvent(AuthorizationEvents.CheckUsernameFromCef)]
        public void IsUsernameExist(Player player, string username) => 
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.IsUsernameTakenToCef,
                    Account.IsUsernameTaken(username)
                    );

        [RemoteEvent(AuthorizationEvents.CheckEmailFromCef)]
        public void IsEmailExist(Player player, string email) => 
            CefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.IsUsernameTakenToCef,
                    Account.IsEmailTaken(email)
                    );
        
        #endregion
    }
}