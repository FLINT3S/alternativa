import {VirtualKey} from "../utils/virtualKeys";
import {execEvent} from "../browserManager/browserManager";

let browser: BrowserMp = mp.browsers.new("http://package/web_packages/admin-panel.html")
browser.active = false


mp.events.add("CEF:CLIENT:Global:Echo", (...data: any) => {
  console.log("CEF:CLIENT:Global:Echo", ...data)
  mp.gui.chat.push("CEF:CLIENT:Global:Echo");
})


mp.events.add("playerJoin", (player) => {
  mp.gui.chat.push(`${player.name} has joined the server!`)
})


mp.events.add("playerCommand", (command) => {
  mp.gui.chat.push(`${command}`)
})

mp.keys.bind(VirtualKey.VK_F3, true, () => {
  mp.gui.chat.push(browser.active ? "Close admin panel!" : "Open admin panel!")
  mp.gui.cursor.visible = !mp.gui.cursor.visible
  browser.active = !browser.active;
  execEvent(browser, "CLIENT:CEF:AltAdminPanel:onOpenOverlay", {a: "Hello from CEF!"})
})
