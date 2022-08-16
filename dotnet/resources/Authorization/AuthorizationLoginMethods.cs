using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization
{
    public partial class Authorization
    {
        private void AccountFoundActions(Player player, Account account, string password)
        {
            if (account.Password == password)
                player.TriggerEvent(AuthorizationEvents.LoginSuccessToClient);
            else
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef,
                    $"Неверный пароль для пользователя {account.Username}");
            player.SetAccount(account);
        }

        private void AccountNotFoundActions(Player player, string login)
        {
            AltLogger.Instance.LogDevelopment(new AltEvent(this, "OnLoginSubmitFromCef",
                $"Account not found: {login}"));
            CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Пользователь {login} не найден");
        }
    }
}