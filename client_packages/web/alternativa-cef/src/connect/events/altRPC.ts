import rpc from "rage-rpc"
import {AltEvent} from "@/connect/events/altEvent";
import {AltEventType} from "@/connect/events/altEventType";
import {ModuleDependent} from "@/connect/ModuleDependent";

/**
 * @class altRPC
 *
 * Класс для взаимодействия с клиентом/сервером по RPC (RemoteCallProcedure)
 * */
export class altRPC extends ModuleDependent {
  /**
   * @method register
   *
   * Регистрация слушателя процедуры
   * */
  register(listenerName: string, cb: (...data: any) => void) {
    rpc.register(listenerName, cb)
    return new AltEvent(listenerName, this.moduleName, AltEventType.REGISTER_LISTENER, true)
  }

  async callServer(eventName: string, ...data: any) {
    new AltEvent(eventName, this.moduleName, AltEventType.CALL_SERVER, true, ...data)
    return rpc.callServer(eventName, ...data).then((...data) => {
      new AltEvent(eventName, this.moduleName, AltEventType.CALL_SERVER_RESULT, true, ...data)
      return data
    })
  }
}
