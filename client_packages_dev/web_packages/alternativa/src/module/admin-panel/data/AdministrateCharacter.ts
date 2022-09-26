import type {ILoadModel} from "@/data/LoadModel";
import type {altMP} from "@/connect/events/altMP";


export class AdministrateCharacter implements ILoadModel {
  staticId: number;
  loading: boolean = false;
  private altMp: altMP;

  constructor(altMp: altMP, staticId: number) {
    this.staticId = staticId;
    this.altMp = altMp;
  }

  load(): void {
    this.loading = true;

    this.altMp.triggerServerWithAnswerPending("GetCharacterMainInfo", this.staticId)
      .then(([characterInfo]) => {
        Object.assign(this, JSON.parse(characterInfo as string));
        this.loading = false;
      })
      .catch(() => {
        this.loading = false;
      })
  }
}
