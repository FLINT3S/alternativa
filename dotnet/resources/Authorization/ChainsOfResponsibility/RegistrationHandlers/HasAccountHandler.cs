using AbstractResource;
using Authorization.ChainsOfResponsibility.PlayerConnectedHandlers;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    public class HasAccountHandler : AbstractHandler
    {
        private readonly CefConnect cefConnect;
        
        public HasAccountHandler(CefConnect cefConnect, AbstractHandler? next) : base(next)
        {
            this.cefConnect = cefConnect;
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            player.HasAccountInDb();

        protected override void _Handle(Player player, string login, string password, string email)
        {
            cefConnect.TriggerCef(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "Пользователь с таким Soсial Club уже зарегистрирован"
                );;
        }
    }
}