using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public abstract class AbstractHandler
    {
        private AbstractHandler? Next { get; }

        protected AbstractHandler(AbstractHandler? next)
        {
            Next = next;
        }

        public void Handle(Player player, Account account, string login, string password)
        {
            if (CanHandle(player, account, login, password))
                _Handle(player, account, login, password);
            else
                Next!.Handle(player, account, login, password);
        }

        protected abstract bool CanHandle(Player player, Account account, string login, string password);

        protected abstract void _Handle(Player player, Account account, string login, string password);
    }
}