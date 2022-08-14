using System.Linq;
using System.Reflection;
using Database;
using Database.Models;
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

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceShutdown()
        {
            AltLogger.Instance.LogResource(new AltResourceEvent(this, ResourceEventType.Shutdown));
        }

        public EventString.EventString GetEsFromAttr(MethodBase method)
        {
            var attr = (RemoteEventAttribute)method!.GetCustomAttributes(typeof(RemoteEventAttribute), true)[0];
            var es = AltAbstractResourceEvents.GetEs(attr.RemoteEventString);
            AltLogger.Instance.LogDevelopment(new AltEvent(this, es.Event, es.ToString()));

            return es;
        }
        
        public Account GetAccountFromPlayer(Player player)
        {
            using var db = new AlternativaContext();

            return db.Accounts.FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }
    }
}