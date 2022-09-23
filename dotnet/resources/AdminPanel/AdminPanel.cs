using System;
using System.Reflection;
using AbstractResource;
using AbstractResource.Attributes;
using Database;
using GTANetworkAPI;

namespace AdminPanel
{
    public class AdminPanel : AltAbstractResource
    {
        [Command("testbr")]
        public void CMDOnTestBR(Player player)
        {
            CefConnect.Trigger(player, "onOpenOverlay");
        }
        
        // Список методов: https://www.notion.so/AdminPanel-6f674297202c477087e826165f60178f

        [RemoteEvent(AdminPanelEvents.KillPlayerFromCef), NeedAdminRights(1)]
        public void OnKillPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => player.Health = 0);
                    }
                );

        [RemoteEvent(AdminPanelEvents.ResurrectPlayerFromCef), NeedAdminRights(1)]
        public void OnResurrectPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var character = AltContext.GetCharacter(staticId);
                        character.Resurrect();
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.SetPlayerHealthFromCef), NeedAdminRights(1)]
        public void OnSetPlayerHealthEvent(Player admin, long staticId, int health = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => player.Health = health);
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.SetPlayerArmorFromCef), NeedAdminRights(1)]
        public void OnSetPlayerArmorEvent(Player admin, long staticId, int armor = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => player.Armor = armor);
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.TeleportPlayerHereFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerHereEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => player.Position = admin.Position);
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.TeleportToPlayerFromCef), NeedAdminRights(1)]
        public void OnTeleportToPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => admin.Position = player.Position);
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.TeleportPlayerToPointFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerToPointEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.TeleportPlayerToLocationFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerToLocationEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.ChangePlayerMoneyFromCef), NeedAdminRights(1)]
        public void OnChangePlayerMoneyEvent(Player admin, long staticId, long sum) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var character = AltContext.GetCharacter(staticId);
                        character.AddSumToCash(sum);
                    }
                );
        
        [RemoteEvent(AdminPanelEvents.BanPlayerFromCef), NeedAdminRights(1)]
        public void OnBanPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.MutePlayerFromCef), NeedAdminRights(1)]
        public void OnMutePlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.GetPlayerStatsFromCef), NeedAdminRights(1)]
        public void OnGetPlayerStatsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.SlapPlayerFromCef), NeedAdminRights(1)]
        public void OnSlapPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.GetPunishmentsFromCef), NeedAdminRights(1)]
        public void OnGetPunishmentsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.RepairCarFromCef), NeedAdminRights(1)]
        public void OnRepairCarEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.GetWeaponFromCef), NeedAdminRights(1)]
        public void OnGetWeaponEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
        
        [RemoteEvent(AdminPanelEvents.RemoveWeaponFromCef), NeedAdminRights(1)]
        public void OnRemoveWeaponEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin, 
                MethodBase.GetCurrentMethod()!, 
                () => throw new NotImplementedException());
    }
}