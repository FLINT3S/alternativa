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
            Переместить в точку
            Переместить в локацию
            Добавить/убавить деньги (+по счетам)
            Забанить
            Замутить
            Запросить статы игрока
            Слапнуть
            Список наказаний
            Починить машину
            Выдать оружие
            Забрать оружие
        */

        [RemoteEvent(AdminPanelEvents.KillPlayerFromCef), NeedAdminRights(1)]
        public void OnKillPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                    {
                        var player = (Player)AltContext.GetCharacter(staticId);
                        NAPI.Task.Run(() => player.Health = 0);
                    }
                );
    }
}