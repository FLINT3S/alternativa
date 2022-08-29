using AbstractResource.Connects;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal abstract class AbstractHandler
    {
        protected AbstractHandler(ClientConnect clientConnect, CefConnect cefConnect, AbstractHandler? next)
        {
            ClientConnect = clientConnect;
            Next = next;
            CefConnect = cefConnect;
        }

        protected ClientConnect ClientConnect { get; }

        private AbstractHandler? Next { get; }

        protected CefConnect CefConnect { get; }

        public void Handle(Player player, string login, string password, string email)
        {
            if (CanHandle(player, login, password, email))
                _Handle(player, login, password, email);
            else
                Next!.Handle(player, login, password, email);
        }

        protected abstract bool CanHandle(Player player, string login, string password, string email);

        protected abstract void _Handle(Player player, string login, string password, string email);

        public static AbstractHandler GetChain(ClientConnect clientConnect, CefConnect cefConnect)
        {
            var successRegistrationHandler = new SuccessRegistrationHandler(clientConnect, cefConnect);
            var emailTakenChecker = new EmailTakenChecker(clientConnect, cefConnect, successRegistrationHandler);
            var usernameTakenHandler = new UsernameTakenChecker(clientConnect, cefConnect, emailTakenChecker);
            var hasAccountHandler = new ExistAccountChecker(clientConnect, cefConnect, usernameTakenHandler);
            return hasAccountHandler;
        }
    }
}