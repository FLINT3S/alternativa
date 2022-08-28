using AbstractResource;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandlers
{
    public abstract class AbstractHandler
    {
        private AbstractHandler? Next { get; }
        
        protected CefConnect CefConnect { get; }

        protected AbstractHandler(CefConnect cefConnect, AbstractHandler? next)
        {
            Next = next;
            CefConnect = cefConnect;
        }

        public void Handle(Player player, Account? account, string login, string password)
        {
            if (CanHandle(player, account, login, password))
                _Handle(player, account, login, password);
            else
                Next!.Handle(player, account, login, password);
        }

        protected abstract bool CanHandle(Player player, Account? account, string login, string password);

        protected abstract void _Handle(Player player, Account? account, string login, string password);
    }
}