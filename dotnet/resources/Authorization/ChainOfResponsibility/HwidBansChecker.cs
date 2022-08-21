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

        protected override bool CanHandle(Player player) => player.GetBanByHwid() != null;

        protected override void _Handle(Player player)
        {
            var hwidBan = player.GetBanByHwid()!;
            player.TriggerEvent(AuthorizationEvents.PermanentlyBanned, hwidBan.Reason, hwidBan.Description);
        }
    }
}