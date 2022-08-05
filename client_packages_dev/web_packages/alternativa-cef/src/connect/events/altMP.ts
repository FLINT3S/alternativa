/**
 * @class altMP
 *
 * Класс для взаимодействия с клиентом посредством событий
 * */
import {AltEvent} from "@/connect/events/altEvent";
import {ModuleDependent} from "@/connect/ModuleDependent";
import {AltEventType} from "@/connect/events/altEventType";
import {altLog} from "@/connect/logs/altLogger";

// @ts-ignore
window.altListeners = new Map<string, Array<(...data: any) => void>>();

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
    const es = `CLIENT:CEF:${this.moduleName}:${eventName}`
    // @ts-ignore
    const currentListeners = window.altListeners.get(es)
    console.log(es, currentListeners)
    if (!currentListeners) {
      // @ts-ignore
      window.altListeners.set(es, [callback])
    } else {
      // @ts-ignore
      window.altListeners.set(es, [...currentListeners, callback])
    }
    // @ts-ignore
    console.log("After add", window.altListeners)
    // @ts-ignore
    console.log("After add for es", window.altListeners.get(es))
  }

  call(eventString: string, data: object) {
    console.trace(eventString, data)
    console.log(eventString, data)
    // @ts-ignore
    console.log("On es", window.altListeners)
    // @ts-ignore
    console.log("On es concrete", window.altListeners.get(eventString))
    new AltEvent(eventString, this.moduleName, AltEventType.RECEIVE, false, ...data)
    // @ts-ignore
    const eventListeners: Array<(...data: any) => void> = window.altListeners.get(eventString)
    if (!eventListeners || eventListeners.length === 0) altLog.warning(`No listeners for event ${eventString}`)
    else eventListeners.forEach(listener => listener(...data))
  }
}
