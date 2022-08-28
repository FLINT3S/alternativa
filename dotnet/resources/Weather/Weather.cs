using AbstractResource;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace Weather
{
    public class Main : AltAbstractResource
    {
        public Main()
        {
            
        }
        
        [ServerEvent(Event.ResourceStart)]
        public void OnWeatherStart()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Started));
        }
        
        public void Get
    }
}
