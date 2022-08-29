using AbstractResource;
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
            connectHandlersChain = PlayerConnectedHandlers.AbstractHandler.GetChain();
            registrationHandlersChain = RegistrationHandlers.AbstractHandler.GetChain(CefConnect);
            loginHandlersChain = LoginHandlers.AbstractHandler.GetChain(CefConnect);
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

        [RemoteEvent(AuthorizationEvents.CheckSocialClubIdFromCef)]
        public void IsSocialClubIdExist(Player player) => 
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.IsSocialClubIdTakenToCef,
                    Account.IsSocialClubIdTaken(player.SocialClubId)
                    );

        [RemoteEvent(AuthorizationEvents.CheckUsernameFromCef)]
        public void IsUsernameExist(Player player, string username) => 
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.IsUsernameTakenToCef,
                    Account.IsUsernameTaken(username)
                    );

        [RemoteEvent(AuthorizationEvents.CheckEmailFromCef)]
        public void IsEmailExist(Player player, string email) => 
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.IsEmailTakenToCef,
                    Account.IsEmailTaken(email)
                    );
        
        #endregion
    }
}