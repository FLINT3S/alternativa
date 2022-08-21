using System.Threading.Tasks;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class HwidBansChecker : AbstractHandler
    {
        public HwidBansChecker(AbstractHandler? next = null) : base(next)
        {
        }

        protected override async Task<bool> CanHandle(Player player) => await player.GetBanByHwid() != null;

        protected override async Task _Handle(Player player)
        {
            var hwidBan = (await player.GetBanByHwid())!;
            player.TriggerEvent(AuthorizationEvents.PermanentlyBanned, hwidBan.Reason, hwidBan.Description);
            throw new System.NotImplementedException();
        }
    }
}