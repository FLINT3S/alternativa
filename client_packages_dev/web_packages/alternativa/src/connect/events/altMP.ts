// Проверка отключена из-за использования window.и mp в коде плагина

declare global {
  interface Window {
    altListeners: Map<string, Set<AltEventCallback>>
  }

  let mp: any;
}

import {AltEvent} from "@/connect/events/altEvent";
import {ModuleDependent} from "@/connect/moduleDependent";
import type {AltEventCallback} from "@/connect/events/altEventType";
import {AltEventType} from "@/connect/events/altEventType";
import {altLog} from "@/connect/logger/altLogger";
import {EventString} from "@/connect/events/eventString";

window.altListeners = new Map<string, Set<AltEventCallback>>();

export type eventFrom = "SERVER" | "CLIENT";

/**
 * @class altMP
 *
 * Класс для взаимодействия с клиентом посредством событий
 * */
export class altMP extends ModuleDependent {
  /**
   * @method trigger
   *
   * Отправляет событие клиенту
   * */
  triggerClient(eventName: string, ...data: Array<number | string>) {
    const es = new EventString("CEF", "CLIENT", this.moduleName, eventName)
    new AltEvent(es, AltEventType.SEND, data)

    mp.trigger(es.eventString, ...data)
  }

  triggerClientRaw(eventString: string, ...data: any[]) {
    mp.trigger(eventString, ...data)
  }

  /**
   * @method callServer
   *
   * Отправляет событие серверу
   * */
  triggerServer(eventName: string, ...data: Array<number | string>) {
    const es = new EventString("CEF", "SERVER", this.moduleName, eventName)
    new AltEvent(es, AltEventType.SEND, data)

    mp.trigger("CEF:SERVER", es.eventString, ...data)
  }

  triggerServerRaw(eventString: string, ...data: any[]) {
    mp.trigger("CEF:SERVER", eventString, ...data)
  }

  /**
   * @method triggerServerWithAnswerPending
   *
   * Отправляет событие серверу и ожидает ответа
   * */
  triggerServerWithAnswerPending(eventName: string, ...data: Array<number | string>): Promise<Array<number | string | boolean>> {
    // TODO: Типизировать коллбэки и промисы
    return new Promise((resolve, reject) => {
      const answerEs = new EventString("CEF", "SERVER", this.moduleName, `${eventName}Answered`)
      const rejectTimeout = setTimeout(() => {
        reject(new Error(`No answer for event ${eventName}`))
      }, 10000)

      this.onRaw(answerEs.eventString, (...data: any[]) => {
        clearTimeout(rejectTimeout)
        resolve(data)
        window.altListeners?.delete(answerEs.eventString)
      })

      this.triggerServer(eventName, ...data)
    })
  }

  triggerServerRawEvent(eventString: string, data?: Array<number | string>) {
    mp.trigger("CEF:SERVER", eventString, JSON.stringify(data))
  }

  /**
   * @method on
   *
   * Добавляет обработчик события от клиента
   * */
  on(eventName: string, callback: (...data: any) => void, moduleName = "", eventFrom: eventFrom = "CLIENT"): () => void {
    const es = new EventString(eventFrom, "CEF", moduleName || this.moduleName, eventName)
    this.onRaw(es.eventString, callback)

    return () => {
      this.off(eventName, callback, moduleName, eventFrom)
    }
  }

  off(eventName: string, callback: (...data: any) => void, moduleName = "", eventFrom: eventFrom = "CLIENT") {
    const es = new EventString(eventFrom, "CEF", moduleName || this.moduleName, eventName)

    window.altListeners.get(es.eventString)?.delete(callback)
  }

  clear(eventName: string, moduleName = "", eventFrom: eventFrom = "CLIENT") {
    const es = new EventString(eventFrom, "CEF", moduleName || this.moduleName, eventName)

    window.altListeners.get(es.eventString)?.clear()
  }

  onRaw(eventString: string, callback: (...data: any) => void) {
    const es = new EventString(eventString)
    new AltEvent(es, AltEventType.REGISTER_LISTENER)

    const currentListeners = window.altListeners.get(es.eventString)
    if (!currentListeners) {
      window.altListeners.set(es.eventString, new Set([callback]))
    } else {
      currentListeners.add(callback)

      if (currentListeners.size > 2) {
        altLog.warning(`Event ${es.eventString} has ${currentListeners.size} listeners`)
      }
    }
  }

  /**
   * @method onServer
   *
   * Добавляет обработчик события от сервера
   * */
  onServer(eventName: string, callback: (...data: any) => void, moduleName = "") {
    return this.on(eventName, callback, moduleName, "SERVER")
  }

  onServerRawEventString(eventString: EventString, callback: (...data: any) => void, moduleName = "") {
    this.onServer(eventString.name, callback, moduleName)
  }

  /**
   * @method onClient
   *
   * Фунция для вызова локального события. Используется на клиенте для триггера событий через execute
   */
  call(eventString: string, data: any[] = []) {
    altLog.warning(eventString)

    const es = new EventString(eventString)
    new AltEvent(es, AltEventType.RECEIVED, data)

    const eventListeners = window.altListeners.get(eventString)
    if (!eventListeners || eventListeners.size === 0) altLog.warning(`No listeners for event ${eventString}`)
    else {
      // @ts-ignore
      eventListeners.forEach(listener => listener(...data))
    }
  }
}
