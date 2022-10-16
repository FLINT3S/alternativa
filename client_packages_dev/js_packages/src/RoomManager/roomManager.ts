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

const loadInterior = (ipl: string = "", coordinates: Vector3MpLike = localPlayer.position) => {
  const interior = mp.game.interior.getInteriorAtCoords(coordinates.x, coordinates.y, coordinates.z)
  loadByIPL(ipl)
  mp.game.interior.refreshInterior(interior)
}

const unloadInterior = (ipl: string = "", coordinates: Vector3MpLike = localPlayer.position) => {
  const interior = mp.game.interior.getInteriorAtCoords(coordinates.x, coordinates.y, coordinates.z)
  unloadByIPL(ipl)
  mp.game.interior.refreshInterior(interior)
}

mp.events.add(RoomManagerEvents.LOAD_INTERIOR, loadInterior)
mp.events.add(RoomManagerEvents.UNLOAD_INTERIOR, unloadInterior)

mp.events.add(RoomManagerEvents.LOAD_INTERIOR_FROM_CEF, loadInterior)
mp.events.add(RoomManagerEvents.UNLOAD_INTERIOR_FROM_CEF, unloadInterior)


const onOpenHouseInterface = () => {
  RMBrowser.browser.execClient("Root", "ShowMessage", "Типа заходим в дом")
}

mp.events.add(RoomManagerEvents.OPEN_HOUSE_INTERFACE, onOpenHouseInterface)
