import {VirtualKey} from "../utils/virtualKeys";
import "./noclip.js"
import {logger} from "../utils/logger";
import {ModuleBrowser} from "../BrowserManager/altBrowser";

const characterManagerBrowser = new ModuleBrowser("AdminPanel", "/admin-panel/index")

mp.keys.bind(VirtualKey.VK_F3, true, () => {
  characterManagerBrowser.setAsActive()
})

mp.events.add("CEF:CLIENT:Root:Execute", (code: string) => {
  eval(code)
})
