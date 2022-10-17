export class CurrentPlayer {
  socialClubId: string = "";
  characterId?: number;
  position: any = {x: 0, y: 0, z: 0};
  money?: number;

  updateFromJson(json: any) {
    Object.assign(this, json);
  }
}
