interface ILocalPlayer extends PlayerMp {
  inColShape: boolean;
  inVehicle: boolean;
}

export const localPlayer: ILocalPlayer = <ILocalPlayer>mp.players.local;


localPlayer.inColShape = false;
localPlayer.inVehicle = !!localPlayer.vehicle;
