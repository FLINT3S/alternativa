using System;
using System.Reflection;
using AbstractResource.Annotations;
using AbstractResource.Connects;
using Castle.Core.Internal;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource
{
    public abstract class AltAbstractResource : Script
    {
        protected AltAbstractResource()
        {
            CefConnect = new CefConnect(this);
            ClientConnect = new ClientConnect(this);
        }

        protected CefConnect CefConnect { get; }

        protected ClientConnect ClientConnect { get; }

        protected bool PlayerHasAccessToMethod(Player player, MethodBase method)
        {
            (int playerVipLevel, int playerAdminLevel)  = player.GetAccessLevels();
            int methodVipLevel = method.GetAttribute<NeedVipRightsAttribute>().Level;
            int methodAdminLevel = method.GetAttribute<NeedAdminRightAttribute>().Level;
            return playerVipLevel >= methodVipLevel && playerAdminLevel >= methodAdminLevel;
        }

        #region Logs

        protected void LogPlayer(Player player, string eventName, string eventDescription)
        {
            var altPlayerEvent = new AltPlayerEvent(player.GetString(), this, eventName, eventDescription);
            AltLogger.Instance.LogInfo(altPlayerEvent);
        }
        
        protected void LogEvent(MethodBase @event, string additionalInfo = "")
        {
            string eventName = GetEventString(@event);
            var altEvent = new AltEvent(this, eventName, 
                $"{eventName} fetched{(additionalInfo.Length > 0 ? $"; {additionalInfo}" : string.Empty)}");
            AltLogger.Instance.LogEvent(altEvent);
        }

        private static string GetEventString(MethodBase methodBase) =>
            methodBase.GetCustomAttribute<RemoteEventAttribute>()!.RemoteEventString;

        protected void LogException(Exception exception)
        {
            string exceptionDescription = ParseException(exception);
            if (exception.InnerException != null)
                exceptionDescription += $"Inner exception: {ParseException(exception.InnerException)}";
            AltLogger.Instance.LogCritical(new AltResourceEvent(this, ResourceEventType.Error, exceptionDescription));
        }
        
        #endregion
        
        #region Server Events

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Started));
        }

        [ServerEvent(Event.UnhandledException)]
        public void OnUnhandledException(Exception exception) => LogException(exception);

        private static string ParseException(Exception ex) => $"{ex.GetType().FullName}: {ex.Message} at {ex.Source}. ";

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceShutdown()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Shutdown));
        }

        #endregion
    }
}