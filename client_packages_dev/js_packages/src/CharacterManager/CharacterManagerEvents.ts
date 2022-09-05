export enum CharacterManagerEvents {
  CREATE_CHARACTER_FROM_CEF = "CEF:CLIENT:CharacterManager:CreateCharacter",
  UPDATE_PARENTS_FROM_CEF = "CEF:CLIENT:CharacterManager:UpdateParents",
  CHANGE_GENDER_FROM_CEF = "CEF:CLIENT:CharacterManager:ChangeGender",
  UPDATE_FACE_FEATURES_FROM_CEF = "CEF:CLIENT:CharacterManager:UpdateFaceFeatures",
  EXECUTE_CHARACTER_CREATION = "CEF:CLIENT:CharacterManager:ExecuteCharacterCreation",
  CHARACTER_CREATED_SUBMIT_FROM_CEF = "CEF:CLIENT:CharacterManager:CharacterCreatedSubmit",

  CREATE_CHARACTER_INIT_TO_SERVER = "CLIENT:SERVER:CharacterManager:InitCharacterCreation",
  CREATE_CHARACTER_FINISH_TO_SERVER = "CLIENT:SERVER:CharacterManager:CharacterCreationFinish",

  CREATE_CHARACTER_START = "SERVER:CLIENT:CharacterManager:CharacterCreationStart",
  GENDER_CHANGED_FROM_SERVER = "SERVER:CLIENT:CharacterManager:GenderChanged",
  CHARACTER_CREATED_FROM_SERVER = "SERVER:CLIENT:CharacterManager:CharacterCreated",
  APPLY_CHARACTER_FROM_SERVER = "SERVER:CLIENT:CharacterManager:ApplyCharacter",
}
