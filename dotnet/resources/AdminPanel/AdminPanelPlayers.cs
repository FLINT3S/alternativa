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
        [RemoteEvent(AdminPanelEvents.GetAvailableMethodsFromCef)]
        public void OnGetAvailableMethodsEvent(Player player) =>
            CefConnect.TriggerRaw(player, AdminPanelEvents.GetAvailableMethodsFromCef + "Answered",
                AdminActionsJsonBuilder.GetAdminActions(
                    GetType().GetMethods(),
                    method => PlayerHasAccessToMember(player, method)
                )
            );
        
        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.GetOnlineCharactersFromCef)]
        public void OnGetOnlineCharactersEvent(Player admin) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var characters = NAPI.Pools.GetActiveCharacters()
                        .Select(character => new { character.StaticId, character.Fullname });
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                        Formatting = Formatting.Indented
                    };
                    string jsonCharacters = JsonConvert.SerializeObject(characters, settings);
                    CefConnect.TriggerRaw(admin, AdminPanelEvents.GetOnlineCharactersFromCef + "Answered", jsonCharacters);
                    LogPlayer(admin, "GetOnlineCharacters", "Request players list");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.GetCharacterMainInfoFromCef)]
        public void OnGetCharacterMainInfoEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var character = AltContext.GetCharacter(staticId);
                    var characterData = new
                    {
                        character.Fullname,
                        character.Age,
                        Ip = ((Player)character).Address,
                        Login = character.Account.Username,
                        character.Account.SocialClubId,
                        InGameTime = character.InGameSeconds,
                        AccountInGameTime = character.Account.Characters.Select(c => c.InGameSeconds).Sum(),
                        LastConnectionTime = character.Account.Connections
                            .OrderByDescending(c => c.CreatedDate)
                            .First()
                            .CreatedDate
                            .ToString(":dd.MM.yyyy HH:mm:ss"),
                        CurrentPosition = ((Player)character).Position,
                        ((Player)character).Health,
                        ((Player)character).Armor,
                        ((Player)character).GetAccessLevels().AdminLevel,
                        ((Player)character).GetAccessLevels().VipLevel
                    };
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                        Formatting = Formatting.Indented
                    };
                    string jsonCharacter = JsonConvert.SerializeObject(characterData, settings);
                    CefConnect.TriggerRaw(admin, AdminPanelEvents.GetCharacterMainInfoFromCef + "Answered", jsonCharacter);
                    LogPlayer(admin, "GetCharacterMainInfo", $"Request player data with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.KillPlayerFromCef)]
        public void OnKillPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Health = 0);
                    LogPlayer(admin, "KillPlayerAsAdmin", $"Kill player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.ResurrectPlayerFromCef)]
        public void OnResurrectPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var character = AltContext.GetCharacter(staticId);
                    character.Resurrect();
                    LogPlayer(admin, "ResurrectPlayer", $"Resurrect player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.SetPlayerHealthFromCef)]
        public void OnSetPlayerHealthEvent(Player admin, long staticId, int health = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Health = health);
                    LogPlayer(admin, "SetHealth", $"Set health to player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.SetPlayerArmorFromCef)]
        public void OnSetPlayerArmorEvent(Player admin, long staticId, int armor = 100) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Armor = armor);
                    LogPlayer(admin, "SetArmor", $"Set armor to player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.TeleportPlayerHereFromCef)]
        public void OnTeleportPlayerHereEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Position = admin.Position);
                    LogPlayer(admin, "TeleportPlayer", $"Teleported player with static ID {staticId} to self");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.TeleportToPlayerFromCef)]
        public void OnTeleportToPlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => admin.Position = player.Position);
                    LogPlayer(admin, "TeleportToPlayer", $"Teleported to player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.TeleportPlayerToPointFromCef)]
        public void OnTeleportPlayerToPointEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.TeleportPlayerToLocationFromCef)]
        public void OnTeleportPlayerToLocationEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        // TODO: Метод называется change, но деньги добавляет
        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.ChangePlayerMoneyFromCef)] 
        public void OnChangePlayerMoneyEvent(Player admin, long staticId, long sum) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var character = AltContext.GetCharacter(staticId);
                    character.AddSumToCash(sum);
                    LogPlayer(admin, "ChangePlayersMoney", $"Change money of player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.TemporaryBanPlayerFromCef)]
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

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.PermanentBanPlayerFromCef)]
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

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.MutePlayerFromCef)]
         public void OnMutePlayerEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.GetPlayerStatsFromCef)]
        public void OnGetPlayerStatsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.SlapPlayerFromCef)]
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

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.GetPunishmentsFromCef)]
        public void OnGetPunishmentsEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.RepairCarFromCef)]
        public void OnRepairCarEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.Vehicle.Repair());
                    LogPlayer(admin, "RepairCar", $"Repair car to player with static ID {staticId}");
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.GiveWeaponFromCef)]
        public void OnGetWeaponEvent(Player admin, long staticId, ulong weapon, int weaponAmmo = 5) =>
            CheckPermissionsAndExecute(admin, MethodBase.GetCurrentMethod()!, () =>
                {
                    var player = (Player)AltContext.GetCharacter(staticId);
                    NAPI.Task.Run(() => player.GiveWeapon((WeaponHash)weapon, weaponAmmo));
                }
            );

        [NeedAdminRights(1)]
        [AdminEventType(AdminEventType.Player)]
        [RemoteEvent(AdminPanelEvents.RemoveWeaponFromCef)]
        public void OnRemoveWeaponEvent(Player admin, long staticId) =>
            CheckPermissionsAndExecute(
                admin,
                MethodBase.GetCurrentMethod()!,
                () => throw new NotImplementedException()
            );

    }
}