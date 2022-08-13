export const altBrowsers = {}

type AltBrowserOptions = {
  toggleCursor?: boolean,
  overlayCloseTimeout?: number,
}

export class AltBrowser {
  protected readonly instance: BrowserMp;
  // name - название браузера, должно быть таким же как и название ресурса
  public name: string;
  public options: AltBrowserOptions = {toggleCursor: false, overlayCloseTimeout: 500}

  constructor(url: string, name: string, options?: object) {
    this.instance = mp.browsers.new(url)
    this.instance.active = false
    this.name = name
    Object.assign(this.options, options)
    altBrowsers[this.name] = this
  }

  get active(): boolean {
    return this.instance.active
  }

  set active(value: boolean) {
    this.instance.active = value
  }

  execEvent(event: string, data: object = {}) {
    this.instance.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  }
}

// Ловит события с сервера и отправляет в нужный браузер
// Негласное правило, что browserName = resourceName
mp.events.add("SERVER:CEF", (browserName: string, eventString: string, data: object) => {
  altBrowsers[browserName].execEvent(eventString, data)
})
