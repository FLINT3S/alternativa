export enum AltEventType {
  RECEIVED,
  SEND,
  // Зарегистрирован слушатель обычных событий
  REGISTER_LISTENER,
  UNREGISTER_LISTENER,
}

export type AltEventCallback = (data: object) => void

export enum AltRPCEventType {
  RECEIVED,
  // Вызвана сервкерная процедура
  CALL_SERVER,
  // Зарегистрирован слушатель обычных событий
  REGISTER_LISTENER,
  UNREGISTER_LISTENER,
}
