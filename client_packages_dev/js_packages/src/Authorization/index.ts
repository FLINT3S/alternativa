import {VirtualKey} from "../utils/virtualKeys";
import {AltBrowser} from "../BrowserManager/altBrowser";
import "./spawnCamera.js"

let cameraOnPlayer = false
let loginCam
let authorizationBrowser: AltBrowser = new AltBrowser("http://package/web_packages/authorization.html", "Authorization", {toggleCursor: true});


mp.events.add("playerReady", () => {
  loginCam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), 40);
  mp.players.local.position = new mp.Vector3(-1757.12, -739.53, 10);

  mp.players.local.freezePosition(true);
  mp.game.ui.setMinimapVisible(true);
  mp.gui.chat.activate(false);
  mp.gui.chat.show(false);
  mp.game.ui.displayRadar(false);

  loginCam.setActive(true);
  loginCam.setCoord(-1757.12, -739.53, 25);
  loginCam.pointAtCoord(-1757.12, -739.53, 22);
  mp.game.cam.renderScriptCams(true, false, 0, true, false);
  mp.events.call("moveSkyCamera", mp.players.local, "up", 1, true)
})

mp.events.add("browserDomReady", (browser) => {
  if (browser.url === authorizationBrowser.url) {
    authorizationBrowser.show()
  }
})

mp.keys.bind(VirtualKey.VK_F5, true, () => {
  authorizationBrowser.toggle()
})

mp.events.add("CEF:CLIENT:Authorization:LoginSuccess", () => {
  loginCam.destroy();

  mp.game.cam.renderScriptCams(false, false, 0, false, false);
  mp.players.local.freezePosition(false);
  mp.game.ui.setMinimapVisible(false);
  mp.gui.chat.activate(true);
  mp.gui.chat.show(true);
  mp.game.ui.displayRadar(true);
  authorizationBrowser.hide();

  mp.events.call("moveSkyCamera", mp.players.local, "down", 1, true)
})
