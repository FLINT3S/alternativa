export enum AltEventType {
  RECEIVE,
  SEND,
  CALL_SERVER,
  CALL_SERVER_RESULT,
  // Зарегистрирован слушатель обычных событий
  REGISTER_LISTENER,
  UNREGISTER_LISTENER,
}
