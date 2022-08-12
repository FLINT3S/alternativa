import {AltEventType} from "@/connect/events/altEventType";
import {altLog} from "@/connect/logs/altLogger";
import {EventString} from "@/connect/events/eventString";

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
