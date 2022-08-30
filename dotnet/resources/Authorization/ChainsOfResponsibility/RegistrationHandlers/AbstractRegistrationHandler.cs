using AbstractResource.Connects;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal abstract class AbstractRegistrationHandler : AbstractHandler
    {
        protected AbstractRegistrationHandler(ClientConnect clientConnect, CefConnect cefConnect, AbstractRegistrationHandler? next)
        {
            ClientConnect = clientConnect;
            Next = next;
            CefConnect = cefConnect;
        }
        
        protected CefConnect CefConnect { get; }
        
        protected ClientConnect ClientConnect { get; }

        private AbstractRegistrationHandler? Next { get; }

        protected override string EventName => "RegistrationFailure";

        public void Handle(Player player, string login, string password, string email)
        {
            if (CanHandle(player, login, password, email))
                _Handle(player, login, password, email);
            else
                Next!.Handle(player, login, password, email);
        }

        protected abstract bool CanHandle(Player player, string login, string password, string email);

        protected abstract void _Handle(Player player, string login, string password, string email);

        public static AbstractRegistrationHandler GetChain(ClientConnect clientConnect, CefConnect cefConnect)
        {
            var successRegistrationHandler = new SuccessRegistrationHandler(clientConnect, cefConnect);
            var emailTakenChecker = new EmailTakenChecker(clientConnect, cefConnect, successRegistrationHandler);
            var usernameTakenHandler = new UsernameTakenChecker(clientConnect, cefConnect, emailTakenChecker);
            var hasAccountHandler = new ExistAccountChecker(clientConnect, cefConnect, usernameTakenHandler);
            return hasAccountHandler;
        }
    }
}