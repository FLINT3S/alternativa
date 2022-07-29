using System;
using System.Runtime.InteropServices;
using GTANetworkAPI;

namespace resourceManager
{
    public class Main : Script
    {
        [Command("rrestart")]
        public static void RestartResource(Player player, String resourceName, Boolean startIfNotRunning = true)
        {
            NAPI.Resource.StopResource(resourceName);
            NAPI.Resource.StopResource(NAPI.Resource.GetResourceName(resourceName));
            NAPI.Resource.StartResource(resourceName);
        }

        [Command("rtest")]
        public static void ResourceTest(Player player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, $"Resource 'testResource123' - ${NAPI.Resource.GetResourceName("testResource")}");
        }

        [Command("rstop")]
        public static void ResourceStop(Player player, String resourceName)
        {
            NAPI.Resource.StopResource(resourceName);
            NAPI.Resource.StopResource(NAPI.Resource.GetResourceName(resourceName));
        }
        
        [Command("rstart")]
        public static void ResourceStart(Player player, String resourceName)
        {
            NAPI.Resource.StartResource(resourceName);
            NAPI.Resource.StartResource(NAPI.Resource.GetResourceName(resourceName));
        }
    }
}