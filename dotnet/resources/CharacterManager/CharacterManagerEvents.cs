namespace CharacterManager
{
    internal static class CharacterManagerEvents
    {
        #region Character Select

        public const string GetOwnCharacters = "CEF:SERVER:CharacterManager:GetOwnCharacters";
        
        public const string SelectCharacter = "CEF:SERVER:CharacterManager:SelectCharacter";

        #endregion

        #region Character Create

        public const string InitCharacterCreationFromClient = "CLIENT:SERVER:CharacterManager:InitCharacterCreation";

        public const string CharacterCreationStart = "SERVER:CLIENT:CharacterManager:CharacterCreationStart";

        public const string ChangeGenderFromCef = "CEF:SERVER:CharacterManager:ChangeGender";

        public const string CharacterCreatedSubmitFromClient = "CLIENT:SERVER:CharacterManager:CharacterCreationFinish";
        
        #endregion
    }
}