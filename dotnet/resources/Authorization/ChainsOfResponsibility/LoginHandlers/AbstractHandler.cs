using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    internal abstract class AbstractHandler
    {
        protected AbstractHandler(ClientConnect clientConnect, CefConnect cefConnect, AbstractHandler? next)
        {
            ClientConnect = clientConnect;
            Next = next;
            CefConnect = cefConnect;
        }

        public ClientConnect ClientConnect { get; }

        private AbstractHandler? Next { get; }

        protected CefConnect CefConnect { get; }

        public void Handle(Player player, Account? account, string login, string password)
        {
            if (CanHandle(player, account, login, password))
                _Handle(player, account, login, password);
            else
                Next!.Handle(player, account, login, password);
        }

        protected abstract bool CanHandle(Player player, Account? account, string login, string password);

        protected abstract void _Handle(Player player, Account? account, string login, string password);

        public static AbstractHandler GetChain(ClientConnect clientConnect, CefConnect cefConnect)
        {
            var successLoginHandler = new SuccessLoginHandler(clientConnect, cefConnect);
            var doubleLoginChecker = new DoubleLoginChecker(clientConnect, cefConnect, successLoginHandler);
            var passwordHandler = new PasswordChecker(clientConnect, cefConnect, doubleLoginChecker);
            var loginHandler = new LoginChecker(clientConnect, cefConnect, passwordHandler);
            var existAccountChecker = new ExistAccountChecker(clientConnect, cefConnect, loginHandler);
            return existAccountChecker;
        }
    }
}