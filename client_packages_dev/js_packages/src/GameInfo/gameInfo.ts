import {InfoHudData} from "./data/InfoHudData";
import {FPS} from "./FpsCalculator";
import {browserManager} from "../BrowserManager/browserManager";
import {AltBrowser} from "../BrowserManager/altBrowser";
import {VirtualKey} from "../utils/virtualKeys";

const debugHudInfo = new InfoHudData();
const rootBrowser: AltBrowser = browserManager.getBrowser("alt")

const UPDATE_INTERVAL = 100;
let showDebugHud = false;
let updateInterval;

const initDebugHud = () => {
  updateInterval = setInterval(() => {
    rootBrowser.executeCode(`window.setGameInfo(${JSON.stringify(debugHudInfo)})`);

    debugHudInfo.fps = FPS.get();
    debugHudInfo.position = mp.players.local.position;
    debugHudInfo.heading = mp.players.local.getHeading();

    if (mp.players.local.vehicle) {
      debugHudInfo.velocityVec = mp.players.local.vehicle.getVelocity();
    } else {
      debugHudInfo.velocityVec = new mp.Vector3(0, 0, 0);
    }
  }, UPDATE_INTERVAL);
}

mp.keys.bind(VirtualKey.VK_OEM_6, true, () => {
  if (showDebugHud) {
    showDebugHud = false
    clearInterval(updateInterval);
    rootBrowser.execEvent("CLIENT:CEF:DebugHud:setDebugHudVisibility", false);
  } else {
    showDebugHud = true
    initDebugHud();
    rootBrowser.execEvent("CLIENT:CEF:DebugHud:setDebugHudVisibility", true);
  }
})
