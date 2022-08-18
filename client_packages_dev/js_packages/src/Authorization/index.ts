import {VirtualKey} from "../utils/virtualKeys";
import {AltOverlayBrowser} from "../BrowserManager/altBrowser";
import "./spawnCamera.js"
import {AuthorizationEvents} from "./AuthorizationEvents";
import {browserManager} from "../BrowserManager/browserManager";
import {logger} from "../utils/logger";

let loginCam
let authorizationBrowser: AltOverlayBrowser = new AltOverlayBrowser("http://package/web_packages/authorization.html", "Authorization", {toggleCursor: true});


mp.events.add("playerReady", () => {
  loginCam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), 40);
  mp.players.local.position = new mp.Vector3(-1757.12, -739.53, 10);

  mp.players.local.freezePosition(true);
  mp.game.ui.setMinimapVisible(true);
  // mp.gui.chat.activate(false);
  // mp.gui.chat.show(false);
  mp.game.ui.displayRadar(false);

  loginCam.setActive(true);
  loginCam.setCoord(-1757.12, -739.53, 25);
  loginCam.pointAtCoord(-1757.12, -739.53, 22);
  mp.game.cam.renderScriptCams(true, false, 0, true, false);
  mp.events.call("moveSkyCamera", mp.players.local, "up", 1, true)
})

mp.events.add("browserDomReady", (browser) => {
  mp.events.call("AltBrowserLoaded_" + browserManager.getByUrl(browser.url).name)
  logger.log("AltBrowserLoaded_" + browserManager.getByUrl(browser.url).name)

  if (browser.url === authorizationBrowser.url) {
    authorizationBrowser.openOverlay()

    browserManager.onBrowserLoad("CharacterManager").then(() => {
      mp.events.callRemote(AuthorizationEvents.PLAYER_READY_TO_SERVER)
    })
  }
})

mp.events.add(AuthorizationEvents.FIRST_CONNECTION_FROM_SERVER, () => {
  authorizationBrowser.execClient("WelcomeScreen")
})

mp.events.add(AuthorizationEvents.NEED_LOGIN_FROM_SERVER, () => {
  authorizationBrowser.execClient("LoginScreen")
})

mp.keys.bind(VirtualKey.VK_F5, true, () => {
  authorizationBrowser.toggleOverlay()
})

mp.events.add(AuthorizationEvents.LOGIN_SUCCESS_FROM_SERVER, () => {
  mp.events.call(AuthorizationEvents.GO_TO_CHARACTER_MANAGER)
  authorizationBrowser.closeOverlay()
  // loginCam.destroy();
  //
  // mp.game.cam.renderScriptCams(false, false, 0, false, false);
  // mp.players.local.freezePosition(false);
  // mp.game.ui.setMinimapVisible(false);
  // mp.gui.chat.activate(true);
  // mp.gui.chat.show(true);
  // mp.game.ui.displayRadar(true);
  // authorizationBrowser.hide();
  //
  // mp.events.call("moveSkyCamera", mp.players.local, "down", 1, true)
})
