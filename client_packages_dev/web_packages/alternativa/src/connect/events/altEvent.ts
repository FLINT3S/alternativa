import type {AltEventType} from "@/connect/events/altEventType";
import type {EventString} from "@/connect/events/eventString";
import {altLog} from "@/connect/logger/altLogger";

export class AltEvent {
  eventString: EventString
  type: AltEventType
  data?: object


  constructor(eventString: EventString, type: AltEventType, data?: object) {
    this.eventString = eventString
    this.type = type
    this.data = data

    altLog.event(this)
  }
}
