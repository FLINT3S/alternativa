using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal abstract class AbstractLoginHandler : AbstractHandler
    {
        protected AbstractLoginHandler(ClientConnect clientConnect, CefConnect cefConnect, AbstractLoginHandler? next)
        {
            ClientConnect = clientConnect;
            Next = next;
            CefConnect = cefConnect;
        }

        protected ClientConnect ClientConnect { get; }

        protected CefConnect CefConnect { get; }

        private AbstractLoginHandler? Next { get; }

        protected override string EventName => "LoginFailure";

        public void Handle(Player player, Account? account, string login, string password)
        {
            if (CanHandle(player, account, login, password))
                _Handle(player, account, login, password);
            else
                Next!.Handle(player, account, login, password);
        }

        protected abstract bool CanHandle(Player player, Account? account, string login, string password);

        protected abstract void _Handle(Player player, Account? account, string login, string password);

        public static AbstractLoginHandler GetChain(ClientConnect clientConnect, CefConnect cefConnect)
        {
            var successLoginHandler = new SuccessLoginHandler(clientConnect, cefConnect);
            var passwordHandler = new PasswordChecker(clientConnect, cefConnect, successLoginHandler);
            var loginHandler = new LoginChecker(clientConnect, cefConnect, passwordHandler);
            var existAccountChecker = new ExistAccountChecker(clientConnect, cefConnect, loginHandler);
            return existAccountChecker;
        }
    }
}