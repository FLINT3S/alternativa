namespace AdminPanel
{
    internal static class AdminPanelEvents
    {
        public const string GetAvailableMethodsFromCef = "CEF:SERVER:AdminPanel:GetAvailableMethods";

        #region Players Events
        
        public const string GetOnlineCharactersFromCef = "CEF:SERVER:AdminPanel:GetOnlineCharacters";

        public const string GetCharacterMainInfoFromCef = "CEF:SERVER:AdminPanel:GetCharacterMainInfo";

        public const string KillPlayerFromCef = "CEF:SERVER:AdminPanel:KillPlayer";

        public const string ResurrectPlayerFromCef = "CEF:SERVER:AdminPanel:ResurrectPlayer";

        public const string SetPlayerHealthFromCef = "CEF:SERVER:AdminPanel:SetPlayerHealth";

        public const string SetPlayerArmorFromCef = "CEF:SERVER:AdminPanel:SetPlayerArmor";

        public const string ChangeDimensionFromCef = "CEF:SERVER:AdminPanel:ChangeDimension";

        public const string TeleportPlayerHereFromCef = "CEF:SERVER:AdminPanel:TeleportPlayerHere";

        public const string TeleportToPlayerFromCef = "CEF:SERVER:AdminPanel:TeleportToPlayer";

        public const string TeleportPlayerToPointFromCef = "CEF:SERVER:AdminPanel:TeleportPlayerToPoint";

        public const string TeleportPlayerToLocationFromCef = "CEF:SERVER:AdminPanel:TeleportPlayerToLocation";

        public const string ChangePlayerMoneyFromCef = "CEF:SERVER:AdminPanel:ChangePlayerMoney";

        public const string TemporaryBanPlayerFromCef = "CEF:SERVER:AdminPanel:TemporaryBanPlayer";

        public const string PermanentBanPlayerFromCef = "CEF:SERVER:AdminPanel:PermanentBanPlayer";

        public const string MutePlayerFromCef = "CEF:SERVER:AdminPanel:MutePlayer";

        public const string GetPlayerStatsFromCef = "CEF:SERVER:AdminPanel:GetPlayerStats";

        public const string SlapPlayerFromCef = "CEF:SERVER:AdminPanel:SlapPlayer";

        public const string GetPunishmentsFromCef = "CEF:SERVER:AdminPanel:GetPunishments";

        public const string RepairCarFromCef = "CEF:SERVER:AdminPanel:RepairCar";

        public const string GiveWeaponFromCef = "CEF:SERVER:AdminPanel:GetWeapon";

        public const string RemoveWeaponFromCef = "CEF:SERVER:AdminPanel:RemoveWeapon";

        #endregion
        
        #region Realty Events
        
        public const string GetHousePrototypes = "CEF:SERVER:AdminPanel:GetHousePrototypes";
        
        public const string CreateSingleHouse = "CEF:SERVER:AdminPanel:CreateSingleHouse";
        
        public const string CreateMultiHouse = "CEF:SERVER:AdminPanel:CreateMultiHouse";

        #endregion
    }
}