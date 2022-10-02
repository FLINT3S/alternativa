import {logger} from "../utils/logger";
import {altBrowser} from "./altBrowser";

// Ловит события с сервера и отправляет в нужный браузер
// Негласное правило, что browserName = resourceName
mp.events.add("SERVER:CEF", (browserName: string, eventString: string, data: Array<number | string>) => {
  logger.log([
    `Received new event to CEF`,
    `For browser "${browserName}"`,
    `Event: "${eventString}"`,
    `With data: ${JSON.stringify(data)}`,
  ], "SERVER:CEF")
  altBrowser.execEvent(eventString, ...data)
})

mp.events.add("CEF:SERVER", (eventString: string, ...data: Array<number | string>) => {
  logger.log([
    `Send new event to Server`,
    `Event: "${eventString}"`,
    `With data: ${JSON.stringify(data)}`,
  ], "SERVER:CEF")
  mp.events.callRemote(eventString, ...data)
})
