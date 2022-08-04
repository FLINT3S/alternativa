/**
 * @class altMP
 *
 * Класс для взаимодействия с клиентом посредством событий
 * */
import {AltEvent} from "@/connect/events/altEvent";
import {ModuleDependent} from "@/connect/ModuleDependent";
import {AltEventType} from "@/connect/events/altEventType";

export class altMP extends ModuleDependent {
  /**
   * @method trigger
   *
   * Отправляет событие клиенту
   * */
  trigger(eventName: string, ...data: any) {
    new AltEvent(eventName, this.moduleName, AltEventType.SEND, true, ...data)
    // @ts-ignore
    mp.trigger(eventString, ...data)
  }

  /**
   * @method on
   *
   * Добавляет обработчик события
   * */
  on(eventName: string, callback: (...data: any) => void) {
    new AltEvent(eventName, this.moduleName, AltEventType.REGISTER_LISTENER, false)
    // @ts-ignore
    window.addEventListener(eventName, (e: CustomEvent) => {
      const _dataReceived = e.detail
      new AltEvent(eventName, this.moduleName, AltEventType.RECEIVE, false, _dataReceived)
      callback(_dataReceived)
    })
  }
}
