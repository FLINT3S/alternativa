export const execEvent = (browser: BrowserMp, event: string, data: object = {}) => {
  browser.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
}
