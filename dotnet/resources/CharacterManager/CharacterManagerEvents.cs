namespace CharacterManager
{
    internal static class CharacterManagerEvents
    {
        public const string InitCharacterCreationFromClient = "CLIENT:SERVER:CharacterManager:InitCharacterCreation";
        public const string CharacterCreationStart = "SERVER:CLIENT:CharacterManager:CharacterCreationStart";
        public const string ChangeGenderFromCef = "CEF:SERVER:CharacterManager:ChangeGender";
    }
}
