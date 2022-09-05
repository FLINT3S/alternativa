export const logger = {
  log: (str: string[] | string, header: string = "LOG") => {
    mp.gui.chat.push(`===== ${header} [${new Date().getCurrentTime()}] =====`)
    if (typeof str === "string") {
      mp.gui.chat.push(str)
    } else {
      str.forEach((line: string) => {
        mp.gui.chat.push(line)
      })
    }
  }
}
