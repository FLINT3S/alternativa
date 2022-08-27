import {AltEvent} from "@/connect/events/altEvent";
import {AltEventType, AltRPCEventType} from "@/connect/events/altEventType";
import {AltRPCEvent} from "@/connect/events/rpc/altRPCEvent";

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

  static universalEvent(event: AltEvent | AltRPCEvent) {
    console.groupCollapsed("Event string:", event.eventString.eventString)
    console.log("Module:", event.eventString.module)
    console.log("Name:", event.eventString.name)
    console.log("From:", event.eventString.from)
    console.log("To:", event.eventString.to)
    if (event instanceof AltEvent) {
      console.log("Type:", AltEventType[event.type])
    } else {
      console.log("Type:", AltRPCEventType[event.type])
    }
    console.groupEnd()

    console.log(event.data)
    console.groupEnd()
  }

  static event(event: AltEvent) {
    if (altLog.logLevel === "event" || altLog.logLevel === "info") {
      console.groupCollapsed(`[EV ${AltEventType[event.type]}] ${event.eventString.module}:${event.eventString.name}`)

      altLog.universalEvent(event)
    }
  }

  static rpcEvent(event: AltRPCEvent) {
    if (altLog.logLevel === "event" || altLog.logLevel === "info") {
      console.groupCollapsed(`[RPC ${AltRPCEventType[event.type]}] ${event.eventString.module}:${event.eventString.name}`)

      altLog.universalEvent(event)
    }
  }
}
