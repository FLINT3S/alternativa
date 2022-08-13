import {AltOverlayBrowser} from "../browserManager/overlayBrowser";
import {VirtualKey} from "../utils/virtualKeys";
import {altBrowsers} from "../browserManager/browserManager";

let adminPanelBrowser: AltOverlayBrowser = new AltOverlayBrowser("http://package/web_packages/admin-panel.html", "AdminPanel", {toggleCursor: true});

mp.keys.bind(VirtualKey.VK_F3, true, () => {
  adminPanelBrowser.toggleOverlay()
})

mp.keys.bind(VirtualKey.VK_F4, true, () => {
  mp.gui.chat.push(JSON.stringify(altBrowsers))
})
