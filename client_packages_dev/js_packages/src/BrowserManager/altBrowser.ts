import {browserManager} from "./browserManager";

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
    this.instance.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  }

  execClient(eventName: string, ...data: Array<string | number>) {
    this.execEvent(`CLIENT:CEF:${this.name}:${eventName}`, ...data)
  }
}

export class AltOverlayBrowser extends AltBrowser {
  private isOverlayOpened: boolean = false
  private closeTimer: NodeJS.Timeout

  constructor(url: string, name: string, options?: object) {
    super(url, name, options)
  }

  openOverlay() {
    clearTimeout(this.closeTimer)
    this.show()

    this.isOverlayOpened = true
    this.execEvent(`CLIENT:CEF:${this.name}:onOpenOverlay`)
  }

  closeOverlay(noHideCursorForce: boolean = false): Promise<boolean> {
    this.isOverlayOpened = false
    this.execEvent(`CLIENT:CEF:${this.name}:onCloseOverlay`)


    return new Promise((resolve) => {
      this.closeTimer = setTimeout(() => {
          this.hide(noHideCursorForce)
          resolve(true)
        },
        this.options.overlayCloseTimeout
      )
    })
  }

  toggleOverlay() {
    this.isOverlayOpened ? this.closeOverlay() : this.openOverlay()
  }
}
