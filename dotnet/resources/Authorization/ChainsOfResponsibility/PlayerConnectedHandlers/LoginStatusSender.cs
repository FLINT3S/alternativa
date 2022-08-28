using Authorization.ChainsOfResponsibility.RegistrationHandlers;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    public class LoginStatusSender : AbstractHandler
    {
        public LoginStatusSender() : base(null)
        {
        }
        
        protected override bool CanHandle(Player player) => true;

        protected override void _Handle(Player player)
        {
            var account = player.GetAccountFromDb()!;
            player.SetAccount(account!);
            account.OnConnect(player.Address, player.Serial);
            
            var character = player.GetActiveCharacter();
            
            if (account.IsSetActiveCharacter())
                LocalContext.EntityLists.OnlinePlayers.Add(account);
            
            if (character?.LastPosition != null)
                player.Position = character.LastPosition;

            player.TriggerEvent(
                    account.IsSameLastHwid(player.Serial) ?
                        AuthorizationEvents.LoginSuccessToClient : AuthorizationEvents.NeedLoginToClient
                );
        }
    }
}