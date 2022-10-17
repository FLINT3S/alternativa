import "./noclip.js"
import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {keyboardMapping} from "../Managers/keyboardManager";

const adminPanelBrowser = new ModuleBrowser("AdminPanel", "/admin-panel/index")

mp.keys.bind(keyboardMapping.ToggleAdminPanel, true, () => {
  adminPanelBrowser.setAsActive()
  adminPanelBrowser.browser.toggleOverlay()
})

mp.events.add("CEF:CLIENT:Root:Execute", (code: string) => {
  eval(code)
})
