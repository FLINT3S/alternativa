import {altBrowser} from "../BrowserManager/altBrowser";
import {logger} from "../utils/logger";

interface ILocalPlayer extends PlayerMp {
  inColShape: boolean;
  money: number;
  socialClubId: string;
  characterId: number;
}

export const localPlayer: ILocalPlayer = <ILocalPlayer>mp.players.local;


localPlayer.inColShape = false;

mp.events.add("CEF:CLIENT:Root:GetCurrentPosition", () => {
  altBrowser.execClient("Root", "SendCurrentPosition", JSON.stringify(localPlayer.position));
})

mp.events.addDataHandler("CharacterMoneyCash", (entity: EntityMp, value: number) => {
  if (entity.type !== "player") return;
  const moneyFromVar = localPlayer.getVariable("CharacterMoneyCash");
  logger.log(`[Money] ${moneyFromVar} => ${value}`);
})
