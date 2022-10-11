import {localPlayer} from "./localPlayerManager";
import {VirtualKey} from "../utils/virtualKeys";
import {logger} from "../utils/logger";


mp.events.add("playerEnterColshape", () => {
  logger.log("player enter colshape");
  localPlayer.inColShape = true
})

mp.events.add("playerExitColshape", () => {
  logger.log("player exit colshape");
  localPlayer.inColShape = false
})

mp.keys.bind(VirtualKey.VK_KEY_E, true, () => {
  logger.log("Outsite colshape")
  if (localPlayer.inColShape) {
    logger.log("In colshape, E press catched")
    mp.events.callRemote("CLIENT:SERVER:RoomManager:InteractOnColShape")
  }
})

mp.events.add("SERVER:CLIENT:RoomManager:OpenApartmentHouseInterface", (entranceId: string) => {
  logger.log("Open apartment house interface " + entranceId)
})
