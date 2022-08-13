using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace AbstractResource
{
    public abstract class AltAbstractResource : Script
    {
        protected CefConnect CefConnect;

        public AltAbstractResource()
        {
            CefConnect = new CefConnect(this);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Started));
        }
    }
}