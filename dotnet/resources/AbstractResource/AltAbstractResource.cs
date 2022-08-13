using System.Reflection;
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
        
        public EventString.EventString GetEsFromAttr(MethodBase method)
        {
            var attr = (RemoteEventAttribute)method!.GetCustomAttributes(typeof(RemoteEventAttribute), true)[0];
            var es = AltAbstractResourceEvents.GetEs(attr.RemoteEventString);
            AltLogger.Instance.LogDevelopment(new AltEvent(this, es.Event, es.ToString()));
            
            return es;
        }
    }
}