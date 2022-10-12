import {InfoHudData} from "./data/InfoHudData";
import {FPS} from "./FpsCalculator";
import {browserManager} from "../BrowserManager/browserManager";
import {AltBrowser} from "../BrowserManager/altBrowser";
import {VirtualKey} from "../utils/virtualKeys";
import {localPlayer} from "../Managers/localPlayerManager";

const debugHudInfo = new InfoHudData();
const rootBrowser: AltBrowser = browserManager.getBrowser("alt")

const UPDATE_INTERVAL = 100;
let showDebugHud = false;
let updateInterval;

const initDebugHud = () => {
  updateInterval = setInterval(() => {
    rootBrowser.executeCode(`window.setDataRender(${JSON.stringify(debugHudInfo)})`);

    debugHudInfo.fps = FPS.get();
    debugHudInfo.position = localPlayer.position;
    debugHudInfo.heading = localPlayer.getHeading();

    if (localPlayer.inVehicle) {
      debugHudInfo.velocity = localPlayer.vehicle.getSpeed() * 3.6;
    } else {
      debugHudInfo.velocity = 0
    }
  }, UPDATE_INTERVAL);
}

mp.keys.bind(VirtualKey.VK_OEM_6, true, () => {
  if (showDebugHud) {
    showDebugHud = false
    clearInterval(updateInterval);
  } else {
    showDebugHud = true
    initDebugHud();
  }
})
