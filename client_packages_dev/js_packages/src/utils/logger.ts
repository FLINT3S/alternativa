export const logger = {
  log: (str: string[], header: string = "LOG") => {
    mp.gui.chat.push(`===== ${header} [${new Date().getCurrentTime()}] =====`)
    str.forEach((line: string) => {
      mp.gui.chat.push(line)
    })
    mp.gui.chat.push(`========================`)
  }
}
