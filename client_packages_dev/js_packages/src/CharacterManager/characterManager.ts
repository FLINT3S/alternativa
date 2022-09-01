import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {AuthorizationEvents} from "../Authorization/AuthorizationEvents";
import {CharacterManagerEvents} from "./CharacterManagerEvents";
import {loginCam} from "../Authorization/authorization";
import {VirtualKey} from "../utils/virtualKeys";
import {logger} from "../utils/logger";

const characterManagerBrowser = new ModuleBrowser("CharacterManager", "/character-manager/select-character")
let characterCreationCamera: CameraMp = mp.cameras.new('default', new mp.Vector3(-752.297, 316.276, 176), new mp.Vector3(0, 0, 0), 45);
let activeCamera = null;
const localPlayer = mp.players.local;

mp.events.add(AuthorizationEvents.GO_TO_CHARACTER_MANAGER, () => {
  characterManagerBrowser.setAsActive()
})


mp.events.add(CharacterManagerEvents.CREATE_CHARACTER_FROM_CEF, () => {
  characterManagerBrowser.browser.closeOverlay().then(() => {
    mp.events.callRemote(CharacterManagerEvents.CREATE_CHARACTER_INIT_TO_SERVER)
  })
})

mp.events.add(CharacterManagerEvents.CREATE_CHARACTER_START, () => {
  loginCam.destroy();
  activeCamera = "character"

  mp.events.call("moveSkyCamera", mp.players.local, "down", 3, true)
  mp.players.local.freezePosition(true);
  mp.players.local.clearTasksImmediately();

  characterCreationCamera.setActive(true);
  characterCreationCamera.setCoord(-751.958, 318.39, 176);
  characterCreationCamera.pointAtCoord(-754.459, 318.391, 176.0);

  mp.game.cam.renderScriptCams(true, false, 0, true, false);

  setTimeout(() => {
    characterManagerBrowser.browser.goTo("/character-manager/create-character")
    characterManagerBrowser.browser.overlayBackdrop = false
    characterManagerBrowser.browser.openOverlay(true)
  }, 5000)

  // mp.players.local.freezePosition(false);
  // mp.game.ui.setMinimapVisible(false);
  // mp.gui.chat.activate(true);
  // mp.gui.chat.show(true);
  // mp.game.ui.displayRadar(true);
})

mp.events.add(CharacterManagerEvents.UPDATE_PARENTS_FROM_CEF, (parentsData) => {
  localPlayer.setHeadBlendData(
    parentsData.father, parentsData.mother, 0,
    parentsData.father, parentsData.mother, 0,
    parentsData.similarity, parentsData.skinSimilarity, 0,
    false
  );
})

mp.events.add(CharacterManagerEvents.UPDATE_FACE_FEATURE_FROM_CEF, (index, value) => {
  localPlayer.setFaceFeature(index, value)
})

mp.events.add(CharacterManagerEvents.EXECUTE_CHARACTER_CREATION, (localPlayerExecData) => {
  if (localPlayer[localPlayerExecData.method]) {
    localPlayer[localPlayerExecData.method](...localPlayerExecData.value)
  }
})

mp.keys.bind(VirtualKey.VK_F4, true, () => {
  logger.log(JSON.stringify(mp.players.local.position))
  logger.log(JSON.stringify(characterCreationCamera.getCoord()))
})

let lmbPressed = false;
mp.events.add('click', (x, y, upOrDown, leftOrRight, relativeX, relativeY, worldPosition, hitEntity) => {
  if (leftOrRight === "left" && upOrDown === "down") {
    lmbPressed = true;
  } else if (leftOrRight === "left" && upOrDown === "up") {
    lmbPressed = false;
  }
})

const mouseSensitivity = 100;
const zoomSpeed = 1.5;
const minZoom = 18.0;
const maxZoom = 75.0;
let radius = 1.7;
let angle = 0;
let zAngle = 0;
let safeX = [0, 900]

mp.events.add('render', () => {
  if (characterCreationCamera !== null && characterCreationCamera.isActive() && characterCreationCamera.isRendering()) {
    if (mp.gui.cursor.position[0] < safeX[0] || mp.gui.cursor.position[0] > safeX[1]) return

    mp.game.controls.disableAllControlActions(2);
    let x = (mp.game.controls.getDisabledControlNormal(7, 1) * mouseSensitivity);
    let y = (mp.game.controls.getDisabledControlNormal(7, 2) * mouseSensitivity);
    let zoomIn = (mp.game.controls.getDisabledControlNormal(2, 40) * zoomSpeed);
    let zoomOut = (mp.game.controls.getDisabledControlNormal(2, 41) * zoomSpeed);

    if (lmbPressed) {
      let angleDiv = 0.5

      angle -= (x / (300 / angleDiv))

      const zAngleDelta = (y / (500 / angleDiv))

      if (zAngle < 0.7 && y < 0) {
        zAngle -= zAngleDelta
      } else if (zAngle > -0.4 && y > 0) {
        zAngle -= zAngleDelta
      }

      let camX = radius * Math.cos(angle) - 754.459;
      let camY = radius * Math.sin(angle) + 318.391;
      let camZ = radius * Math.sin(zAngle) + 176.0;

      characterCreationCamera.setCoord(camX, camY, camZ);
    }

    if (zoomIn > 0) {
      let currentFov = characterCreationCamera.getFov();
      currentFov -= zoomIn;
      if (currentFov < minZoom)
        currentFov = minZoom;
      characterCreationCamera.setFov(currentFov);
    } else if (zoomOut > 0) {
      let currentFov = characterCreationCamera.getFov();
      currentFov += zoomOut;
      if (currentFov > maxZoom)
        currentFov = maxZoom;
      characterCreationCamera.setFov(currentFov);
    }
  }
});
