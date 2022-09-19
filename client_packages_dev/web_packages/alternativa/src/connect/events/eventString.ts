import {altDefaultEventRegexp} from "@/connect/events/utils/regExps";

export class EventString {
  eventString: string
  from: string
  to: string
  module: string
  name: string

  constructor(...args: [string] | [string, string] | [string, string, string, string]) {
    if (args.length === 1 && args[0].match(altDefaultEventRegexp)) {
      this.eventString = args[0]
      this.from = this.eventString.split(":")[0]
      this.to = this.eventString.split(":")[1]
      this.module = this.eventString.split(":")[2]
      this.name = this.eventString.split(":")[3]
    } else if (args.length === 4) {
      this.from = args[0]
      this.to = args[1]
      this.module = args[2]
      this.name = args[3]
      this.eventString = `${this.from}:${this.to}:${this.module}:${this.name}`
    } else if (args.length === 2) {
      this.from = "CEF"
      this.to = "CLIENT"
      this.module = args[0]
      this.name = args[1]
      this.eventString = `${this.from}:${this.to}:${this.module}:${this.name}`
    } else {
      throw new Error("Invalid arguments passed to EventString constructor: " + JSON.stringify(args))
    }
  }
}
