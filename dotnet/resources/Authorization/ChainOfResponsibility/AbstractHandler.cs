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
        
        public async Task Handle(Player player)
        {
            if (await CanHandle(player))
                await _Handle(player);
            else
                await next!.Handle(player);
        }
        
        protected abstract Task<bool> CanHandle(Player player);

        protected abstract Task _Handle(Player player);
    }
}