import {AltBrowser} from "./altBrowser";

export class AltOverlayBrowser extends AltBrowser {
  private isOverlayOpened: boolean = false;
  private closeTimers: Map<string, NodeJS.Timeout>;

  constructor(url: string, name: string, options?: object) {
    super(url, name, options)
  }

  openOverlay(overlayName?: string) {
    if (this.options.toggleCursor) {
      mp.gui.cursor.visible = true
    }

    this.isOverlayOpened = true
    this.active = true
    this.execEvent(`CLIENT:CEF:${this.name}:onOpenOverlay`, {overlayName})
  }

  closeOverlay(overlayName?: string) {
    if (this.options.toggleCursor) {
      mp.gui.cursor.visible = false
    }

    this.isOverlayOpened = false
    this.execEvent(`CLIENT:CEF:${this.name}:onCloseOverlay`, {overlayName})

    this.closeTimers.set(overlayName, setTimeout(() => {
      this.active = false
      this.instance.destroy()
    }, this.options.overlayCloseTimeout))
  }

  toggleOverlay(overlayName?: string) {
    this.isOverlayOpened ? this.closeOverlay(overlayName) : this.openOverlay(overlayName)
  }
}
