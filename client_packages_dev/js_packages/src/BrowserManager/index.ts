import {VirtualKey} from "../utils/virtualKeys";
import {AltBrowser, AltOverlayBrowser} from "./altBrowser";
import {browserManager} from "./browserManager";
import {logger} from "../utils/logger";

// Ловит события с сервера и отправляет в нужный браузер
// Негласное правило, что browserName = resourceName
mp.events.add("SERVER:CEF", (browserName: string, eventString: string, data: Array<number | string>) => {
  logger.log([
    `Received new event to CEF`,
    `For browser "${browserName}"`,
    `Event: "${eventString}"`,
    `With data: ${JSON.stringify(data)}`,
  ], "SERVER:CEF")
  global.altBrowsers[browserName].execEvent(eventString, ...data)
})

mp.events.add("CEF:SERVER", (eventString: string, ...data: Array<number | string>) => {
  mp.events.callRemote(eventString, ...data)
})

mp.keys.bind(VirtualKey.VK_ESCAPE, true, () => {
  Object.values(browserManager.getAllBrowsers()).forEach((browser: AltBrowser) => {
    if (browser instanceof AltOverlayBrowser) {
      browser.closeOverlay()
    }
  })
})
