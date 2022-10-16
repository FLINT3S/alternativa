import {localPlayer} from "../Managers/localPlayerManager";
import {RoomManagerEvents} from "./RoomManagerEvents";
import {ModuleBrowser} from "../BrowserManager/altBrowser";

const RMBrowser = new ModuleBrowser("RoomManager", "/room-manager")

const loadByIPL = (ipl: string) => {
  mp.game.streaming.requestIpl(ipl)
}

const unloadByIPL = (ipl: string) => {
  mp.game.streaming.removeIpl(ipl)
}

const loadInterior = (ipl: string = "", coordinates: Vector3MpLike | string = localPlayer.position) => {
  if (typeof coordinates === "string") {
    coordinates = JSON.parse(coordinates) as Vector3MpLike
  }

  const interior = mp.game.interior.getInteriorAtCoords(coordinates.x, coordinates.y, coordinates.z)
  loadByIPL(ipl)
  mp.game.interior.refreshInterior(interior)
}

const unloadInterior = (ipl: string = "", coordinates: Vector3MpLike | string = localPlayer.position) => {
  if (typeof coordinates === "string") {
    coordinates = JSON.parse(coordinates) as Vector3MpLike
  }

  const interior = mp.game.interior.getInteriorAtCoords(coordinates.x, coordinates.y, coordinates.z)
  unloadByIPL(ipl)
  mp.game.interior.refreshInterior(interior)
}

mp.events.add(RoomManagerEvents.LOAD_INTERIOR, loadInterior)
mp.events.add(RoomManagerEvents.UNLOAD_INTERIOR, unloadInterior)

mp.events.add(RoomManagerEvents.LOAD_INTERIOR_FROM_CEF, loadInterior)
mp.events.add(RoomManagerEvents.UNLOAD_INTERIOR_FROM_CEF, unloadInterior)


const onOpenHouseInterface = (houseId) => {
  RMBrowser.browser.goTo("/room-manager/house-interface/" + houseId);
  RMBrowser.browser.openOverlay();
}

mp.events.add(RoomManagerEvents.OPEN_HOUSE_INTERFACE, onOpenHouseInterface)
