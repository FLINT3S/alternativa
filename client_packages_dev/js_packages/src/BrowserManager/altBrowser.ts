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

  show() {
    if (this.options.toggleCursor) {
      mp.gui.cursor.visible = true
    }

    this.active = true
  }

  hide() {
    if (this.options.toggleCursor) {
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

  execEvent(event: string, data: object = {}) {
    this.instance.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  }
}

export class AltOverlayBrowser extends AltBrowser {
  private isOverlayOpened: boolean = false;
  private closeTimers: Map<string, NodeJS.Timeout>;

  constructor(url: string, name: string, options?: object) {
    super(url, name, options)
  }

  openOverlay(overlayName?: string) {
    this.show()

    this.isOverlayOpened = true
    this.execEvent(`CLIENT:CEF:${this.name}:onOpenOverlay`, {overlayName})
  }

  closeOverlay(overlayName?: string) {
    if (this.options.toggleCursor) {
      mp.gui.cursor.visible = false
    }

    this.isOverlayOpened = false
    this.execEvent(`CLIENT:CEF:${this.name}:onCloseOverlay`, {overlayName})

    // FIXME: Не вызывается таймаут
    this.closeTimers.set(overlayName, setTimeout(() => {
      mp.gui.chat.push("Окно закрыто")
        this.hide()
      },
      this.options.overlayCloseTimeout))
  }

  toggleOverlay(overlayName?: string) {
    this.isOverlayOpened ? this.closeOverlay(overlayName) : this.openOverlay(overlayName)
  }
}
