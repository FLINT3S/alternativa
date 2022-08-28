import {browserManager} from "./browserManager";
import {logger} from "../utils/logger";
import Timer = NodeJS.Timer;

export enum AltBrowserLevel {
  DEFAULT,
  IMPORTANT
}

type AltBrowserOptions = {
  toggleCursor?: boolean,
  overlayCloseTimeout?: number,
  level: AltBrowserLevel
}

export class AltBrowser {
  protected readonly instance: BrowserMp;
  // name - название браузера, должно быть таким же как и название ресурса
  public name: string;
  public options: AltBrowserOptions = {toggleCursor: false, overlayCloseTimeout: 500, level: AltBrowserLevel.DEFAULT}
  public loaded: boolean;
  private overlayTimeout: Timer;
  private isOverlayOpen: boolean = true

  constructor(url: string, name: string, options?: object) {
    this.instance = mp.browsers.new(url)
    this.instance.active = false
    this.name = name
    Object.assign(this.options, options)
    browserManager.addBrowser(this)
  }

  get active(): boolean {
    return this.instance.active
  }

  set active(value: boolean) {
    this.instance.active = value
  }

  get url(): string {
    return this.instance.url
  }

  set url(value: string) {
    this.instance.url = value
  }

  set overlayBackdrop(show: boolean) {
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

  openOverlay(showCursor: boolean = true): Promise<boolean> {
    clearTimeout(this.overlayTimeout)

    return new Promise((resolve) => {
      this.execEvent("CLIENT:CEF:Root:onOpenOverlay")
      this.isOverlayOpen = true
      this.show()

      if (showCursor) {
        mp.gui.cursor.visible = true
      }

      this.overlayTimeout = setTimeout(() => {
        resolve(true)
      }, this.options.overlayCloseTimeout)
    })
  }

  closeOverlay(forceHide: boolean = false, hideCursor: boolean = true): Promise<boolean> {
    return new Promise((resolve) => {
      this.execEvent("CLIENT:CEF:Root:onCloseOverlay")
      this.isOverlayOpen = false
      this.overlayTimeout = setTimeout(() => {
        if (forceHide) {
          this.hide(!hideCursor)
        }

        if (hideCursor) {
          mp.gui.cursor.visible = false
        }

        resolve(true)
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

  execEvent(event: string, ...data: Array<string | number | boolean>) {
    logger.log(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
    this.instance.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  }

  execClient(moduleName: string, eventName: string, ...data: Array<string | number | boolean>) {
    logger.log(`CLIENT:CEF:${moduleName}:${eventName}`, "ExecClient")
    this.execEvent(`CLIENT:CEF:${moduleName}:${eventName}`, ...data)
  }

  goTo(path: string) {
    this.execEvent("CLIENT:CEF:Root:GoTo", path)
  }
}

export const altBrowser = new AltBrowser("http://package/web_packages/index.html", "alt")
altBrowser.show()

export class ModuleBrowser {
  public moduleName: string;
  public browser: AltBrowser = altBrowser;
  private isOverlayOpen: boolean;
  private readonly path: string;

  constructor(moduleName: string, path: string) {
    this.moduleName = moduleName
    this.path = path
  }

  setAsActive() {
    this.browser.goTo(this.path)
  }

  execEvent(eventString: string, ...data: Array<string | number>) {
    this.browser.execEvent(eventString, ...data)
  }

  execClient(eventName: string, ...data: Array<string | number>) {
    this.browser.execClient(this.moduleName, eventName, ...data)
  }
}

