import {altRPCEventRegexp} from "@/connect/events/utils/regExps";

export class RPCEventSting {
  eventString: string
  from: string
  to: string
  module: string
  name: string

  /**
   * @param
   * */
  constructor(...args: [string] | [string, string, string, string]) {
    if (args.length === 1 && args[0].match(altRPCEventRegexp)) {
      // eslint-disable-next-line
      const [_, __, from, to, module, name] = args[0].split(":")
      this.eventString = args[0]
      this.from = from
      this.to = to
      this.module = module
      this.name = name
    } else if (args.length === 4) {
      this.from = args[0]
      this.to = args[1]
      this.module = args[2]
      this.name = args[3]
      this.eventString = `RPC::${this.from}:${this.to}:${this.module}:${this.name}`
    } else {
      throw new Error("Invalid arguments passed to RPCEventString constructor: " + JSON.stringify(args))
    }
  }
}
