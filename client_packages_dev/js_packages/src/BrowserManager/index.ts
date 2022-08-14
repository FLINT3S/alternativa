import {VirtualKey} from "../utils/virtualKeys";
import {AltBrowser, AltOverlayBrowser} from "./altBrowser";
import {browserManager} from "./browserManager";

// Ловит события с сервера и отправляет в нужный браузер
// Негласное правило, что browserName = resourceName
mp.events.add("SERVER:CEF", (browserName: string, eventString: string, data: Array<number|string>) => {
  mp.gui.chat.push(`SERVER:CEF - ${browserName} ${eventString} ${JSON.stringify(data)}`)
  global.altBrowsers[browserName].execEvent(eventString, ...data)
})

mp.events.add("CEF:SERVER", (eventString: string, ...data: Array<number|string>) => {
  mp.events.callRemote(eventString, ...data)
})

mp.keys.bind(VirtualKey.VK_ESCAPE, true, () => {
  Object.values(browserManager.getAllBrowsers()).forEach((browser: AltBrowser) => {
    if (browser instanceof AltOverlayBrowser) {
      browser.closeOverlay()
    }
  })
})
