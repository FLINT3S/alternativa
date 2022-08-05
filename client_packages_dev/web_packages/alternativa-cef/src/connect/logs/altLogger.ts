import {AltEvent} from "@/connect/events/altEvent";
import {AltEventType} from "@/connect/events/altEventType";

export class altLog {
  static set logLevel(logLevel: string) {
    // @ts-ignore
    window.altLogLevelGlobal = logLevel
  }

  static get logLevel(): string {
    // @ts-ignore
    return window.altLogLevelGlobal || process.env.VUE_APP_ALT_LOG_LEVEL || process.env.NODE_ENV === "development" ? "info" : "warning"
  }

  /**
   * @method data
   *
   * Универсавльный логгер для данных
   *
   * @param {any} data Данные
   *
   * [groupName, ...data]
   * [groupName, ...data, plainData: boolean]
   * */
  public static log(...data: any[]) {
    // Обработчик для plainData
    if (typeof data[data.length - 1] === "boolean" && data[data.length - 1]) {
      console.log(...data)
      return
    }

    if (typeof data[0] === "string" && data.length > 1) {
      console.group(data[0])
      console.log(...data.slice(1))
      console.groupEnd()
    } else {
      console.log(...data)
    }
  }

  public static warning(...data: any) {
    console.warn(...data)
  }

  public static error(...data: any) {
    console.error(...data)
  }

  static event(event: AltEvent) {
    if (altLog.logLevel === "event" || altLog.logLevel === "info") {
      console.group(`${event.module}:${event.name}`, `(${AltEventType[event.type]})`)

      console.groupCollapsed("Event string:", event.eventString)
      console.log("RPC:", event.isRPC)
      console.log("Module:", event.module)
      console.log("Name:", event.name)
      console.log("From:", event.from)
      console.log("To:", event.to)
      console.log("Type:", event.type)
      console.groupEnd()

      console.log(...event.data)
      console.groupEnd()
    }
  }
}
