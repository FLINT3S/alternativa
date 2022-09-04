export enum CharacterManagerEvents {
  CREATE_CHARACTER_FROM_CEF = "CEF:CLIENT:CharacterManager:CreateCharacter",
  UPDATE_PARENTS_FROM_CEF = "CEF:CLIENT:CharacterManager:UpdateParents",
  CHANGE_GENDER_FROM_CEF = "CEF:CLIENT:CharacterManager:ChangeGender",
  UPDATE_FACE_FEATURES_FROM_CEF = "CEF:CLIENT:CharacterManager:UpdateFaceFeatures",
  EXECUTE_CHARACTER_CREATION = "CEF:CLIENT:CharacterManager:ExecuteCharacterCreation",

  CREATE_CHARACTER_INIT_TO_SERVER = "CLIENT:SERVER:CharacterManager:InitCharacterCreation",
  CREATE_CHARACTER_START = "SERVER:CLIENT:CharacterManager:CharacterCreationStart"
}
