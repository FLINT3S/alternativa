using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    public abstract class AbstractHandler
    {
        private readonly AbstractHandler? next;

        protected AbstractHandler(AbstractHandler? next)
        {
            this.next = next;
        }

        public void Handle(Player player, Account account, string login, string password)
        {
            if (CanHandle(player, account, login, password))
                _Handle(player, account, login, password);
            else
                next!.Handle(player, account, login, password);
        }

        protected abstract bool CanHandle(Player player, Account account, string login, string password);

        protected abstract void _Handle(Player player, Account account, string login, string password);
    }
}