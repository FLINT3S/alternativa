import {altBrowser} from "../BrowserManager/altBrowser";

interface ILocalPlayer extends PlayerMp {
  inColShape: boolean;
  inVehicle: boolean;
}

export const localPlayer: ILocalPlayer = <ILocalPlayer>mp.players.local;


localPlayer.inColShape = false;
localPlayer.inVehicle = !!localPlayer.vehicle;


mp.events.add("CEF:CLIENT:Root:GetCurrentPosition", () => {
  altBrowser.execClient("Root", "SendCurrentPosition", JSON.stringify(localPlayer.position));
})
