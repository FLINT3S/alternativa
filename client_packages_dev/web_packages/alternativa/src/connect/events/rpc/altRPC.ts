import {ModuleDependent} from "@/connect/moduleDependent";

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
    // const es = new RPCEventSting("SERVER", "CEF", this.moduleName, listenerName)
    // new AltRPCEvent(es, AltRPCEventType.REGISTER_LISTENER)
    //
    // rpc.register(listenerName, cb)
  }

  async callServer(eventName: string, data: any) {
    // const es = new RPCEventSting("CEF", "SERVER", this.moduleName, eventName)
    // new AltRPCEvent(es, AltRPCEventType.CALL_SERVER, data)
    //
    // return rpc.callClient("RPC::CEF:SERVER", [eventName, data]).then((...data: any[]) => {
    //   new AltRPCEvent(es, AltRPCEventType.RECEIVED, data)
    //   return data
    // })
  }
}
