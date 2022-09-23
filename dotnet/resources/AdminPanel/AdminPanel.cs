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
        
        /*
            TODO - список прав администратора
            
            Убить
            Воскресить
            100 Хп
            N Хп
            100 брони
            N брони
            Переместить к себе
            Переместиться к нему
            todo Переместить в точку
            todo Переместить в локацию
            todo Добавить/убавить деньги (+по счетам)
            todo Забанить
            todo Замутить
            todo Запросить статы игрока
            todo Слапнуть
            todo Список наказаний
            todo Починить машину
            todo Выдать оружие
            todo Забрать оружие
        */

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
    }
}