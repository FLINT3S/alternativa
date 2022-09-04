export enum AuthorizationEvents {
  LOGIN_SUCCESS_FROM_SERVER = "SERVER:CLIENT:Authorization:LoginSuccess",
  REGISTER_SUCCESS_FROM_SERVER = "SERVER:CLIENT:Authorization:RegisterSuccess",
  FIRST_CONNECTION_FROM_SERVER = "SERVER:CLIENT:Authorization:FirstConnection",
  NEED_LOGIN_FROM_SERVER = "SERVER:CLIENT:Authorization:NeedLogin",
  CHARACTER_SPAWNED_FROM_SERVER = "SERVER:CLIENT:CharacterManager:OnCharacterSpawned",

  GO_TO_CHARACTER_MANAGER = "CEF:CEF:Authorization:GoToCharacterManager",

  PLAYER_READY_TO_SERVER = "CLIENT:SERVER:Authorization:PlayerReady"
}
