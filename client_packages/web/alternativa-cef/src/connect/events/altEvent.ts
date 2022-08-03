import {AltEventType} from "@/connect/events/altEventType";
import {altDefaultEventRegexp, altRPCEventRegexp} from "@/connect/events/utils/regExps";
import {altLog} from "@/connect/logs/altLogger";

export class AltEvent {
  eventString: string
  name: string
  isRPC: boolean
  from: string
  to: string
  module: string
  type: AltEventType
  data: any


  /**
   * [eventString, ...data]
   * [RPCEventString, ...data]
   * [eventName, eventModule, isRPC, eventType, ...data]
   * */
  constructor(...args: [string, ...any] | [string, string, AltEventType, boolean, ...any] | [string, string, AltEventType, ...any]) {
    const _processReceivedEvent = () => {
      this.eventString = args[0]
      this.name = this.eventString.split(":")[2]
      this.module = this.eventString.split(":")[1]
      this.type = AltEventType.RECEIVE
      this.data = args.slice(1)
    }

    if (args[0].match(altRPCEventRegexp)) {
      this.isRPC = true
      _processReceivedEvent()
    } else if (args[0].match(altDefaultEventRegexp)) {
      this.isRPC = false
      _processReceivedEvent()
    } else {
      this.name = args[0]
      this.from = "CEF"
      this.to = "SERVER"
      if (typeof args[1] === "string") this.module = args[1]
      else this.module = "Global"

      if (typeof args[2] === "number") this.type = args[2]
      else throw new Error("Event type is not defined")

      if (typeof args[3] === "boolean") {
        this.isRPC = args[3]
        this.data = args.slice(4)
      } else {
        this.isRPC = false
        this.data = args.slice(3)
      }
    }

    altLog.event(this)
  }
}
