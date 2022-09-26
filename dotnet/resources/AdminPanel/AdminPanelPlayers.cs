using System;
using System.Linq;
using System.Reflection;
using AbstractResource.Attributes;
using Database;
using Database.Models.Bans;
using GTANetworkAPI;
using NAPIExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AdminPanel
{
    public partial class AdminPanel
    {
        [RemoteEvent(AdminPanelPlayersEvents.GetAvailablePlayersMethodsFromCef)]
        public void OnGetAvailablePlayersMethodsEvent(Player player) =>
            CefConnect.TriggerRaw(player, AdminPanelPlayersEvents.GetAvailablePlayersMethodsFromCef + "Answered",
                AdminPlayersActionsJsonBuilder.GetAdminActions(
                    GetType().GetMethods(),
                    method => PlayerHasAccessToMember(player, method)
                )
            );

        [RemoteEvent(AdminPanelPlayersEvents.GetOnlineCharactersFromCef), NeedAdminRights(1)]
        public void OnGetOnlineCharactersEvent(Player admin) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var characters = NAPI.Pools.GetActiveCharacters()
                        .Select(character => new
                            { character.StaticId, character.Fullname, character.InGameTime, character.Age }
                        );
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                        Formatting = Formatting.Indented
                    };
                    string jsonCharacters = JsonConvert.SerializeObject(characters, settings);
                    CefConnect.TriggerRaw(admin, AdminPanelPlayersEvents.GetOnlineCharactersFromCef + "Answered", jsonCharacters);
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.KillPlayerFromCef), NeedAdminRights(1)]
        public void OnKillPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Health = 0);
                    LogPlayer(admin, "KillPlayerAsAdmin", $"Kill player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.ResurrectPlayerFromCef), NeedAdminRights(1)]
        public void OnResurrectPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var character = AltContext.GetCharacter(staticId);
                    character.Resurrect();
                    LogPlayer(admin, "ResurrectPlayer", $"Resurrect player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.SetPlayerHealthFromCef), NeedAdminRights(1)]
        public void OnSetPlayerHealthEvent(Player admin, long staticId, int health = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Health = health);
                    LogPlayer(admin, "SetHealth", $"Set health to player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.SetPlayerArmorFromCef), NeedAdminRights(1)]
        public void OnSetPlayerArmorEvent(Player admin, long staticId, int armor = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Armor = armor);
                    LogPlayer(admin, "SetArmor", $"Set armor to player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.TeleportPlayerHereFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerHereEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Position = admin.Position);
                    LogPlayer(admin, "TeleportPlayer", $"Teleported player with static ID {staticId} to self");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.TeleportToPlayerFromCef), NeedAdminRights(1)]
        public void OnTeleportToPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => admin.Position = player.Position);
                    LogPlayer(admin, "TeleportToPlayer", $"Teleported to player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.TeleportPlayerToPointFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerToPointEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [RemoteEvent(AdminPanelPlayersEvents.TeleportPlayerToLocationFromCef), NeedAdminRights(1)]
        public void OnTeleportPlayerToLocationEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        // TODO: Метод называется change, но деньги добавляет
        [RemoteEvent(AdminPanelPlayersEvents.ChangePlayerMoneyFromCef), NeedAdminRights(1)]
        public void OnChangePlayerMoneyEvent(Player admin, long staticId, long sum) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var character = AltContext.GetCharacter(staticId);
                    character.AddSumToCash(sum);
                    LogPlayer(admin, "ChangePlayersMoney", $"Change money of player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.TemporaryBanPlayerFromCef), NeedAdminRights(1)]
        public void OnTemporaryBanPlayerEvent(Player admin, long staticId, int reason, long seconds = 0,
            string? message = null) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var account = AltContext.GetCharacter(staticId).Account;
                    var duration = TimeSpan.FromSeconds(seconds);
                    var ban = new TemporaryBan(duration, admin, account, (BanReason)reason, message);
                    account.Ban(ban);
                    LogPlayer(admin, "TemporaryBanPlayer",
                        $"Temporary ban player with static ID {staticId} for {duration} caused {reason}"
                    );
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.PermanentBanPlayerFromCef), NeedAdminRights(1)]
        public void OnPermanentBanPlayerEvent(Player admin, long staticId, int reason, string? message = null) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var account = AltContext.GetCharacter(staticId).Account;
                    var ban = new PermanentBan(admin, account, (BanReason)reason, message);
                    account.Ban(ban);
                    LogPlayer(admin, "PermanentBanPlayer",
                        $"Permanently ban player with static ID {staticId} caused {reason}"
                    );
                    ((Player)account).Ban(reason.ToString());
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.MutePlayerFromCef), NeedAdminRights(1)]
        public void OnMutePlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [RemoteEvent(AdminPanelPlayersEvents.GetPlayerStatsFromCef), NeedAdminRights(1)]
        public void OnGetPlayerStatsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [RemoteEvent(AdminPanelPlayersEvents.SlapPlayerFromCef), NeedAdminRights(1)]
        public void OnSlapPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(
                        () =>
                        {
                            AnimationManager.AnimationManager.StopAnimation(player);
                            player.WarpOutOfVehicle();
                            LogPlayer(admin, "SlapPlayer", $"Slap player with static ID {staticId}");
                        }
                    );
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.GetPunishmentsFromCef), NeedAdminRights(1)]
        public void OnGetPunishmentsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [RemoteEvent(AdminPanelPlayersEvents.RepairCarFromCef), NeedAdminRights(1)]
        public void OnRepairCarEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Vehicle.Repair());
                    LogPlayer(admin, "RepairCar", $"Repair car to player with static ID {staticId}");
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.GiveWeaponFromCef), NeedAdminRights(1)]
        public void OnGetWeaponEvent(Player admin, long staticId, ulong weapon, int weaponAmmo = 5) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.GiveWeapon((WeaponHash)weapon, weaponAmmo));
                }
            );

        [RemoteEvent(AdminPanelPlayersEvents.RemoveWeaponFromCef), NeedAdminRights(1)]
        public void OnRemoveWeaponEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

    }
}