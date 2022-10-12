import {localPlayer} from "./localPlayerManager";
import {VirtualKey} from "../utils/virtualKeys";


mp.events.add("playerEnterColshape", () => {
  localPlayer.inColShape = true
})

mp.events.add("playerExitColshape", () => {
  localPlayer.inColShape = false
})

mp.keys.bind(VirtualKey.VK_KEY_E, true, () => {
  if (localPlayer.inColShape) {
    mp.events.callRemote("CLIENT:SERVER:RoomManager:InteractOnColShape")
  }
})
