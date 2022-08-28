using AbstractResource;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
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

        public void Handle(Player player, string login, string password, string email)
        {
            if (CanHandle(player, login, password, email))
                _Handle(player, login, password, email);
            else
                Next!.Handle(player, login, password, email);
        }

        protected abstract bool CanHandle(Player player, string login, string password, string email);

        protected abstract void _Handle(Player player, string login, string password, string email);
    }
}