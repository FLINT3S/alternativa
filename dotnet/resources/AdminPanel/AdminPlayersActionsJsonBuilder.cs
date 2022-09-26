using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AbstractResource.Attributes;
using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AdminPanel
{
    internal static class AdminPlayersActionsJsonBuilder
    {
        public static string GetAdminActions(MethodInfo[] methods, Predicate<MethodInfo> hasAccess)
        {
            var adminsActions = methods
                .GetAvailableEvents(hasAccess)
                .Select(method => new
                {
                    Name = GetActionTitle(method.GetRemoteEventString()),
                    Command = GetActionCommand(method.GetRemoteEventString()),
                    Description = GetActionDescription(method.GetRemoteEventString()),
                    Params = GetParams(method).Select(param => new
                    {
                        Type = param.Type,
                        Name = param.Name,
                        Description = param.Description
                    })
                }
            );
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(adminsActions, settings);
        }

        private static IEnumerable<MethodInfo> GetAvailableEvents(this MethodInfo[] methods, Predicate<MethodInfo> hasAccess) => methods
            .Where(method => method.GetCustomAttribute<RemoteEventAttribute>() != null)
            .Where(method => method.GetCustomAttribute<NeedAdminRightsAttribute>() != null)
            .Where(method => hasAccess(method));

        private static string GetRemoteEventString(this MethodInfo method) =>
            method.GetCustomAttribute<RemoteEventAttribute>()!.RemoteEventString;

        private static string GetActionTitle(string eventName) => eventName switch
        {
            AdminPanelPlayersEvents.GetOnlineCharactersFromCef => "Получить персонажей в онлайн",
            AdminPanelPlayersEvents.KillPlayerFromCef => "Убить игрока",
            AdminPanelPlayersEvents.ResurrectPlayerFromCef => "Воскресить игрока",
            AdminPanelPlayersEvents.SetPlayerHealthFromCef => "Установить здоровье игрока",
            AdminPanelPlayersEvents.SetPlayerArmorFromCef => "Установить броню игрока",
            AdminPanelPlayersEvents.TeleportPlayerHereFromCef => "Телепортировать игрока сюда",
            AdminPanelPlayersEvents.TeleportToPlayerFromCef => "Телепортироваться к игроку",
            AdminPanelPlayersEvents.TeleportPlayerToPointFromCef => "Телепортировать игрока в точку",
            AdminPanelPlayersEvents.TeleportPlayerToLocationFromCef => "Телепортировать игрока в локацию",
            AdminPanelPlayersEvents.ChangePlayerMoneyFromCef => "Изменить деньги игрока",
            AdminPanelPlayersEvents.TemporaryBanPlayerFromCef => "Временно забанить игрока",
            AdminPanelPlayersEvents.PermanentBanPlayerFromCef => "Насовсем забанить игрока",
            AdminPanelPlayersEvents.MutePlayerFromCef => "Заглушить игрока",
            AdminPanelPlayersEvents.GetPlayerStatsFromCef => "Получить данные об игроке",
            AdminPanelPlayersEvents.SlapPlayerFromCef => "Остановить анимации/выкинуть из транспорта игрока",
            AdminPanelPlayersEvents.GetPunishmentsFromCef => "Получить список наказаний игрока",
            AdminPanelPlayersEvents.RepairCarFromCef => "Починить машину игроку",
            AdminPanelPlayersEvents.GiveWeaponFromCef => "Выдать оружие игроку",
            AdminPanelPlayersEvents.RemoveWeaponFromCef => "Отобрать оружие у игрока",
            _ => throw new ArgumentException("Unexpected method")
        };

        private static string GetActionCommand(string eventName) => eventName.Split(':')[^1];

        private static string GetActionDescription(string eventName) => eventName switch
        {
            _ => string.Empty
        };

        private static IEnumerable<(string Type, string Name, string Description)> GetParams(MethodInfo method) =>
            method.GetParameters()
                .Where(parameter => parameter.ParameterType != typeof(Player))
                .Select(parameter => (
                    GetParamName(parameter), 
                    GetParamType(parameter), 
                    GetParamDescription(parameter)
                    )
                );

        private static string GetParamName(ParameterInfo parameter) => parameter.Name! switch
        {
            "staticId" => "Статический ID игрока",
            "reason" => "Причина",
            "message" => "Сообщение",
            "seconds" => "Число секунд",
            "sum" => "Сумма",
            "weapon" => "Оружие",
            "weaponAmmo" => "Число снарядов",
            _ => "Unnamed parameter"
        };

        private static string GetParamType(ParameterInfo parameter) => parameter.ParameterType.Name switch
        {
            "Int16" => "number",
            "Int32" => "number",
            "Int64" => "number",
            "UInt16" => "number",
            "UInt32" => "number",
            "UInt64" => "number",
            "String" => "string",
            _ when parameter.ParameterType.IsEnum => "number",
            _ => "any"
        };

        private static string GetParamDescription(ParameterInfo parameter) => parameter.Name! switch
        {
            _ => string.Empty
        };
    }
}