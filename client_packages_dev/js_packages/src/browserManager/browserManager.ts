export const execEvent = (browser: BrowserMp, event: string, data: object) => {
  mp.gui.chat.push(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
  browser.execute(`window.altMP.call("${event}", ${JSON.stringify(data)})`)
}
