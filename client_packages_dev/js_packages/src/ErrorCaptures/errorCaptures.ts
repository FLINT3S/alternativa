import {logger} from "../utils/logger";


export class altError {
  static captureError(message: string = "Unspecified error", include_trace=true) {
    let msg = message

    if (include_trace) {
      msg += " Stack:" + getStackTrace()
    }

    mp.events.callRemote('CLIENT:SERVER:Root:Error', msg)
    logger.log(message.toString(), 'ERROR')
  }

  static captureWarning(message: string = "Unspecified warning", include_trace=true) {
    let msg = message

    if (include_trace) {
      msg += " Stack:" + getStackTrace()
    }

    mp.events.callRemote('CLIENT:SERVER:Root:Warning', msg)
    logger.log(message, 'WARNING')
  }
}

export const getStackTrace = () => {
  const obj = {};
  Error.captureStackTrace(obj, getStackTrace);
  // @ts-ignore
  return obj.stack;
};
