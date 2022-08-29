using GTANetworkAPI;

namespace AbstractResource.Connects
{
    public class CefConnect : AbstractConnect
    {
        public CefConnect(object module) : base(module)
        {
        }

        protected override string Receiver => "CEF";

        public override void Trigger(Player player, string eventName, params object?[] args)
        {
            player.TriggerEvent(FromTo, ModuleName, $"{FromTo}:{ModuleName}:{eventName}", args);
        }
    }
}