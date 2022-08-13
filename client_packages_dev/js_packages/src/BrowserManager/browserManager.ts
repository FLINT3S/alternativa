import {AltBrowser} from "./altBrowser";
import {VirtualKey} from "../utils/virtualKeys";
import {AltOverlayBrowser} from "./overlayBrowser";

export const altBrowsers = {}

// Ловит события с сервера и отправляет в нужный браузер
// Негласное правило, что browserName = resourceName
mp.events.add("SERVER:CEF", (browserName: string, eventString: string, data: object) => {
  altBrowsers[browserName].execEvent(eventString, data)
})

mp.events.add("CEF:SERVER", (eventString: string, data: object) => {
  mp.events.callRemote(eventString, data)
})

mp.keys.bind(VirtualKey.VK_ESCAPE, true, () => {
  Object.values(altBrowsers).forEach((browser: AltBrowser) => {
    if (browser instanceof AltOverlayBrowser) {
      browser.closeOverlay()
    }
  })
})

export class BrowserManager {
  static getBrowser(browserName: string): AltBrowser {
    return altBrowsers[browserName]
  }
}
