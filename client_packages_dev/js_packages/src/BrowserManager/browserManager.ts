import {AltBrowser} from "./altBrowser";

export class browserManager {
  static getBrowser(browserName: string): AltBrowser {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return
    }

    return global.altBrowsers[browserName]
  }

  static addBrowser(browser: AltBrowser): void {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
    }

    global.altBrowsers[browser.name] = browser
  }

  static getAllBrowsers(): AltBrowser[] {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return []
    }

    return Object.values(global.altBrowsers)
  }
}
