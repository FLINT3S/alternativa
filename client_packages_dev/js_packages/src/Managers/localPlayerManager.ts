interface ILocalPlayer extends PlayerMp {
  inColShape: boolean;
}

export const localPlayer: ILocalPlayer = <ILocalPlayer>mp.players.local;


localPlayer.inColShape = false;
