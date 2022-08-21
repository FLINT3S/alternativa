using System.Threading.Tasks;
using Database.Models;
using GTANetworkAPI;

namespace Authorization.ChainOfResponsibility
{
    public abstract class AbstractHandler
    {
        private readonly AbstractHandler? next;

        protected AbstractHandler(AbstractHandler? next = null)
        {
            this.next = next;
        }
        
        public void Handle(Player player)
        {
            if (CanHandle(player))
                _Handle(player);
            else
                next!.Handle(player);
        }
        
        protected abstract bool CanHandle(Player player);

        protected abstract void _Handle(Player player);
    }
}