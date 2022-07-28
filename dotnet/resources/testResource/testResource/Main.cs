using GTANetworkAPI;

namespace TestResource
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart() =>
            NAPI.Util.ConsoleOutput("Hello");
    }
}