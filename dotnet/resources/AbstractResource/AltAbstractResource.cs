using System.Reflection;
using AbstractResource.Connects;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource
{
    public abstract class AltAbstractResource : Script
    {
        protected CefConnect CefConnect { get; }
        
        protected ClientConnect ClientConnect { get; }

        protected AltAbstractResource()
        {
            CefConnect = new CefConnect(this);
            ClientConnect = new ClientConnect(this);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Started));
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceShutdown()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Shutdown));
        }

        protected void LogEvent(MethodBase @event)
        {
            string eventName = GetEventString(@event);
            var altEvent = new AltEvent(this, eventName, $"{eventName} fetched");
            AltLogger.Instance.LogEvent(altEvent);
        }

        private static string GetEventString(MethodBase methodBase) =>
            methodBase.GetCustomAttribute<RemoteEventAttribute>()!.RemoteEventString;
    }
}