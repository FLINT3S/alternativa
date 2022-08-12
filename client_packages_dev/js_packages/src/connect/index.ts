import {VirtualKey} from "../utils/virtualKeys";
import {execEvent} from "../browserManager/browserManager";

let browser: BrowserMp = mp.browsers.new("http://package/web_packages/admin-panel.html")
browser.active = false
let isBrowserBlocked = false

mp.events.add("playerJoin", (player) => {
  mp.gui.chat.push(`${player.name} has joined the server!`)
})


mp.events.add("playerCommand", (command) => {
  mp.gui.chat.push(`${command}`)
})

mp.keys.bind(VirtualKey.VK_F3, true, () => {
  if (!isBrowserBlocked) {
    mp.gui.chat.push(browser.active ? "Close admin panel!" : "Open admin panel!")
    if (browser.active) {
      isBrowserBlocked = true
      setTimeout(() => {
        isBrowserBlocked = false
        browser.active = false
      }, 600)
    } else {
      browser.active = true
    }
    execEvent(browser, "CLIENT:CEF:AdminPanel:onToggleOverlay")
    mp.gui.cursor.visible = !mp.gui.cursor.visible
  }
})
