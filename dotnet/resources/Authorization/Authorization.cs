using System.Reflection;
using AbstractResource;
using Authorization.ChainsOfResponsibility.LoginHandlers;
using Authorization.ChainsOfResponsibility.PlayerConnectedHandlers;
using Authorization.ChainsOfResponsibility.RegistrationHandlers;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public class Authorization : AltAbstractResource
    {
        private readonly AbstractConnectionHandler connectHandlersChain;

        private readonly AbstractLoginHandler loginHandlersChain;

        private readonly AbstractRegistrationHandler registrationHandlersChain;

        public Authorization()
        {
            connectHandlersChain = AbstractConnectionHandler.GetChain(ClientConnect);
            registrationHandlersChain = AbstractRegistrationHandler.GetChain(ClientConnect, CefConnect);
            loginHandlersChain = AbstractLoginHandler.GetChain(ClientConnect, CefConnect);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnAuthorizationStart()
        {
            NAPI.Server.SetAutoSpawnOnConnect(false);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnect(Player player, DisconnectionType type, string reason)
        {
            var character = player.GetCharacter();
            character?.OnDisconnect(player);
            player.RemoveCharacter();
        }

        #region RemoteEvents

        // Здесь ивент от клиента (а не PlayerConnected), о том, что он готов к логину
        // (посылается после загрузки основных браузеров)
        [RemoteEvent(AuthorizationEvents.PlayerReadyFromClient)]
        private void OnPlayerConnectedAndReady(Player player)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            connectHandlersChain.Handle(player);
        }

        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            loginHandlersChain.Handle(player, (Account)player, login, password);
        }

        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public void OnRegisterSubmitFromCef(Player player, string login, string password, string email)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            registrationHandlersChain.Handle(player, login, password, email);
        }

        [RemoteEvent(AuthorizationEvents.CheckSocialClubIdFromCef)]
        public void IsSocialClubIdExist(Player player)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            CefConnect.TriggerEvent(
                    player,
                    AuthorizationEvents.IsSocialClubIdTakenToCef,
                    Account.IsSocialClubIdTaken(player.SocialClubId)
                );
        }

        [RemoteEvent(AuthorizationEvents.CheckUsernameFromCef)]
        public void IsUsernameExist(Player player, string username)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            CefConnect.TriggerRaw(
                    player,
                    AuthorizationEvents.CheckUsernameFromCef + "Answered",
                    Account.IsUsernameTaken(username)
                );
        }

        [RemoteEvent(AuthorizationEvents.CheckEmailFromCef)]
        public void IsEmailExist(Player player, string email)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            CefConnect.TriggerRaw(
                player,
                AuthorizationEvents.CheckEmailFromCef + "Answered",
                    Account.IsEmailTaken(email)
                );
        }

        #endregion
    }
}