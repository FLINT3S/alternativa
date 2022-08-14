import {VirtualKey} from "../utils/virtualKeys";
import {AltBrowser} from "../BrowserManager/altBrowser";

let authorizationBrowser: AltBrowser = new AltBrowser("http://package/web_packages/authorization.html", "Authorization", {toggleCursor: true});

mp.keys.bind(VirtualKey.VK_F5, true, () => {
  authorizationBrowser.toggle()
})
