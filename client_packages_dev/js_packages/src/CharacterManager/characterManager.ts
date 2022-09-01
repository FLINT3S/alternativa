import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {AuthorizationEvents} from "../Authorization/AuthorizationEvents";
import {CharacterManagerEvents} from "./CharacterManagerEvents";
import {loginCam} from "../Authorization/authorization";
import {VirtualKey} from "../utils/virtualKeys";
import {logger} from "../utils/logger";
import {rotateCameraSafeZone, setActiveRotateCamera} from "../Managers/rotateCameraManager";

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
  setActiveRotateCamera(characterCreationCamera)
  rotateCameraSafeZone.xLe = 900
  rotateCameraSafeZone.xGe = 300

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
