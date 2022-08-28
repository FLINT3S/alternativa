import {browserManager} from "./browserManager";
import {logger} from "../utils/logger";

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

  toggle() {
    if (this.active) {
      this.hide()
    } else {
      this.show()
    }
  }

  execEvent(event: string, ...data: Array<string | number>) {
    logger.log(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
    this.instance.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  }

  execClient(moduleName: string, eventName: string, ...data: Array<string | number>) {
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

  openOverlay() {
    this.setAsActive()
    this.isOverlayOpen = true
    this.execClient("onOpenOverlay")
  }

  closeOverlay() {
    this.isOverlayOpen = false
    this.execClient("onCloseOverlay")
  }

  toggleOverlay() {
    if (this.isOverlayOpen) {
      this.closeOverlay()
    } else {
      this.openOverlay()
    }
  }
}

