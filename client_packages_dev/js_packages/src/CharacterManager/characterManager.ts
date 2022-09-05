import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {AuthorizationEvents} from "../Authorization/AuthorizationEvents";
import {CharacterManagerEvents} from "./CharacterManagerEvents";
import {loginCam} from "../Authorization/authorization";
import {VirtualKey} from "../utils/virtualKeys";
import {logger} from "../utils/logger";
import {
  removeRotateCamera,
  rotateCameraSafeZone,
  rotateCameraSettings,
  rotateCameraVariables,
  setActiveRotateCamera
} from "../Managers/rotateCameraManager";
import {CharacterData} from "./data/CharacterData";
import {IsCameraInAir} from "../Authorization/spawnCamera.js";
import {animationManager} from "../Managers/animationManager";

const characterManagerBrowser = new ModuleBrowser("CharacterManager", "/character-manager/select-character")
let characterCreationCamera: CameraMp = mp.cameras.new('default', new mp.Vector3(-752.297, 316.276, 176), new mp.Vector3(0, 0, 0), 45);
const localPlayer = mp.players.local;
const characterData = new CharacterData();

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
  mp.game.cam.setCinematicModeActive(false);

  mp.events.call("moveSkyCamera", localPlayer, "down", 3, true)
  localPlayer.freezePosition(true);
  localPlayer.clearTasksImmediately();

  characterCreationCamera.setActive(true);
  characterCreationCamera.setCoord(-751.958, 318.39, 176);
  characterCreationCamera.pointAtCoord(-754.459, 318.391, 176.0);
  setActiveRotateCamera(characterCreationCamera)
  rotateCameraSafeZone.xLe = 900
  rotateCameraSafeZone.xGe = 300

  mp.game.cam.renderScriptCams(true, false, 0, true, false);

  let showCharacterCreatorInterfaceInterval = setInterval(() => {
    if (!IsCameraInAir()) {
      clearInterval(showCharacterCreatorInterfaceInterval)
      characterManagerBrowser.browser.goTo("/character-manager/create-character")
      characterManagerBrowser.browser.overlayBackdrop = false
      characterManagerBrowser.browser.openOverlay(true)
      animationManager.playIdleStay()
      rotateCameraVariables.forceRenderOnce = true
    }
  }, 300)
})

const applyParents = (parentsData) => {
  parentsData = JSON.parse(parentsData)
  characterData.parents = parentsData

  localPlayer.setHeadBlendData(
    parentsData.father.id, parentsData.mother.id, 0,
    parentsData.father.id, parentsData.mother.id, 0,
    parentsData.similarity, parentsData.skinSimilarity, 0,
    false
  )
}

mp.events.add(CharacterManagerEvents.UPDATE_PARENTS_FROM_CEF, applyParents)

const applyFaceFeatures = (faceFeaturesData) => {
  faceFeaturesData = JSON.parse(faceFeaturesData)
  characterData.faceFeatures = faceFeaturesData

  for (let i = 0; i < faceFeaturesData.length; i++) {
    localPlayer.setFaceFeature(i, faceFeaturesData[i])
  }
}

mp.events.add(CharacterManagerEvents.UPDATE_FACE_FEATURES_FROM_CEF, applyFaceFeatures)

mp.events.add(CharacterManagerEvents.CHARACTER_CREATED_SUBMIT_FROM_CEF, (commonCharacterInfo) => {
  characterManagerBrowser.browser.closeOverlay()
  mp.game.cam.doScreenFadeOut(500)

  setTimeout(() => {
    characterData.setCommonInfo(commonCharacterInfo)
    mp.events.callRemote(CharacterManagerEvents.CREATE_CHARACTER_FINISH_TO_SERVER, characterData.dto)
    removeRotateCamera()
    characterCreationCamera.destroy(true)
  }, 2500)
})

mp.events.add(CharacterManagerEvents.GENDER_CHANGED_FROM_SERVER, (gender) => {
  characterData.gender = gender
  animationManager.playIdleStay()

  if (gender === 0) {
    rotateCameraSettings.pointingPosition.z = 176
    characterCreationCamera.pointAtCoord(localPlayer.position.x, localPlayer.position.y, 176)
  } else {
    rotateCameraSettings.pointingPosition.z = 176.15
    characterCreationCamera.pointAtCoord(localPlayer.position.x, localPlayer.position.y, 176.15)
  }

  rotateCameraVariables.forceRenderOnce = true
})

mp.events.add(CharacterManagerEvents.CHARACTER_CREATED_FROM_SERVER, () => {
  mp.game.cam.renderScriptCams(false, false, 0, true, false);
  localPlayer.freezePosition(false);
  mp.game.ui.setMinimapVisible(false);
  mp.gui.chat.activate(true);
  mp.gui.chat.show(true);
  mp.game.ui.displayRadar(true);

  setTimeout(() => {
    mp.game.cam.doScreenFadeIn(500);
  }, 300)
})

mp.events.add(CharacterManagerEvents.APPLY_CHARACTER_FROM_SERVER, (characterData) => {
  characterData = JSON.parse(characterData)

  const parentsData = {
    father: {
      id: characterData.fatherId,
    },
    mother: {
      id: characterData.motherId,
    },
    similarity: characterData.similarity,
    skinSimilarity: characterData.skinSimilarity,
  }

  applyFaceFeatures(JSON.stringify(characterData.faceFeatures))
  applyParents(JSON.stringify(parentsData))
})

mp.events.add(CharacterManagerEvents.EXECUTE_CHARACTER_CREATION, (localPlayerExecData) => {
  if (localPlayer[localPlayerExecData.method]) {
    localPlayer[localPlayerExecData.method](...localPlayerExecData.value)
  }
})

mp.keys.bind(VirtualKey.VK_F4, true, () => {
  logger.log(JSON.stringify(localPlayer.position))
  logger.log(JSON.stringify(characterCreationCamera.getCoord()))
})
