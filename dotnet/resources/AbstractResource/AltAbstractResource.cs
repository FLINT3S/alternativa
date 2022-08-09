using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace AbstractResource
{
    public abstract class AltAbstractResource : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Started));
        }
    }
}