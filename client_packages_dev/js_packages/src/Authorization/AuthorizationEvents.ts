export enum AuthorizationEvents {
  LOGIN_SUCCESS_FROM_SERVER = "SERVER:CLIENT:Authorization:LoginSuccess",
  GO_TO_CHARACTER_MANAGER = "CEF:CEF:Authorization:GoToCharacterManager",
  FIRST_CONNECTION_FROM_SERVER = "SERVER:CLIENT:Authorization:FirstConnection",
  NEED_LOGIN_FROM_SERVER = "SERVER:CLIENT:Authorization:NeedLogin",
  PLAYER_READY_TO_SERVER = "CLIENT:SERVER:Authorization:PlayerReady"
}
