import {browserManager} from "./browserManager";
import {logger} from "../utils/logger";
import {altError} from "../ErrorCaptures/errorCaptures";
import Timer = NodeJS.Timer;
import {VirtualKey} from "../utils/virtualKeys";


type AltBrowserOptions = {
  toggleCursor?: boolean,
  overlayCloseTimeout?: number,
}

export class AltBrowser {
  protected readonly instance: BrowserMp;
  private overlayTimeout: Timer;
  private isOverlayOpen: boolean = true

  public name: string
  public options: AltBrowserOptions = {toggleCursor: false, overlayCloseTimeout: 500}
  public loaded: boolean
  public path: string = ""

  public settings = {
    active: true,
    canCloseOverlay: false,
    openOverlay: true,
    execute: true,
    backdrop: true,
    goTo: true,
    goToAnotherModule: true,
  }

  constructor(url: string, name: string, options?: object) {
    this.instance = mp.browsers.new(url)
    this.instance.active = false
    this.name = name
    Object.assign(this.options, options)
    browserManager.addBrowser(this)
  }

  captureBrowserIncident(err: string, type: string = "ERROR") {
    if (type === "ERROR") {
      altError.captureError(err)
    } else if (type === "WARNING") {
      altError.captureWarning(err)
    }
  }

  get active(): boolean {
    return this.instance.active
  }

  set active(value: boolean) {
    if (!this.settings.active) return
    this.instance.active = value
  }

  get url(): string {
    return this.instance.url
  }

  set url(value: string) {
    this.instance.url = value
  }

  reload(ignoreCache: boolean = false) {
    this.instance.reload(ignoreCache)
  }

  set overlayBackdrop(show: boolean) {
    if (!this.settings.backdrop) {
      altError.captureWarning("Attempt to set overlay backdrop, but it's disabled")
      return
    }

    if (show) {
      this.execEvent("CLIENT:CEF:Root:turnOnBackdrop")
    } else {
      this.execEvent("CLIENT:CEF:Root:turnOffBackdrop")
    }
  }

  getInstance() {
    return this.instance
  }

  show() {
    if (this.options.toggleCursor) {
      mp.gui.cursor.visible = true
    }

    this.active = true
  }

  hide(noHideCursorForce: boolean = false) {
    if (this.options.toggleCursor && !noHideCursorForce) {
      mp.gui.cursor.visible = false
    }

    this.active = false
  }

  openOverlay(showCursor: boolean = true): Promise<void> {
    if (!this.settings.openOverlay) {
      altError.captureWarning("Attempt to open overlay, but it's disabled")
      return
    }

    clearTimeout(this.overlayTimeout)

    return new Promise((resolve) => {
      this.execEvent("CLIENT:CEF:Root:onOpenOverlay")
      this.isOverlayOpen = true
      this.show()

      if (showCursor) {
        mp.gui.cursor.visible = true
      }

      this.overlayTimeout = setTimeout(() => {
        resolve()
      }, this.options.overlayCloseTimeout)
    })
  }

  closeOverlay(hideCursor: boolean = true): Promise<void> {
    if (!this.settings.canCloseOverlay) {
      altError.captureWarning("Attempt to close overlay, but it's disabled")
      return
    }

    return new Promise((resolve) => {
      this.execEvent("CLIENT:CEF:Root:onCloseOverlay")
      this.isOverlayOpen = false
      this.overlayTimeout = setTimeout(() => {
        if (hideCursor) {
          mp.gui.cursor.visible = false
        }

        resolve()
      }, this.options.overlayCloseTimeout)
    })
  }

  toggleOverlay() {
    if (this.isOverlayOpen) {
      return this.closeOverlay()
    } else {
      return this.openOverlay()
    }
  }

  executeCode(code: string) {
    if (!this.settings.execute) {
      this.captureBrowserIncident("Attempt to execute code, but it's disabled", "WARNING")
      return
    }

    this.instance.execute(code)
  }

  execEvent(eventString: string, ...data: Array<string | number | boolean>) {
    this.instance.execute(`window.altMP.call("${eventString}", ${JSON.stringify(data)})`)
  }

  execClient(moduleName: string, eventName: string, ...data: Array<string | number | boolean>) {
    logger.log(`CLIENT:CEF:${moduleName}:${eventName}`, "ExecClient")
    this.execEvent(`CLIENT:CEF:${moduleName}:${eventName}`, ...data)
  }

  goTo(path: string) {
    this.path = path
    const [currentModule, ...currentRest] = this.path.split("/").filter((item) => item !== "")
    const [goToModule, ...goToRest] = path.split("/").filter((item) => item !== "")

    if (!this.settings.goTo) {
      this.captureBrowserIncident(`Attempt to go to ${path}, but it's disabled`, "WARNING")
      return
    }

    if (currentModule !== goToModule && !this.settings.goToAnotherModule) {
      this.captureBrowserIncident("Attempt to go to another module, but it's disabled", "WARNING")
      logger.log(`Err: ${currentModule} -> ${goToModule}`, "GoTo")
      return
    }

    this.execEvent("CLIENT:CEF:Root:GoTo", path)
  }
}

export const altBrowser = new AltBrowser("http://package/web_packages/index.html", "alt")
altBrowser.show()

mp.keys.bind(VirtualKey.VK_F9, true, () => {
  altBrowser.reload(true)
})

export class ModuleBrowser {
  public moduleName: string;
  public browser: AltBrowser = altBrowser;
  private readonly path: string;

  constructor(moduleName: string, path: string) {
    this.moduleName = moduleName
    this.path = path
  }

  setAsActive() {
    this.browser.goTo(this.path)
  }

  execRawEvent(eventString: string, ...data: Array<string | number>) {
    this.browser.execEvent(eventString, ...data)
  }

  execClient(eventName: string, ...data: Array<string | number>) {
    this.browser.execClient(this.moduleName, eventName, ...data)
  }
}

