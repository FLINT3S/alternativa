import type {ILoadModel} from "@/data/LoadModel";
import type {altMP} from "@/connect/events/altMP";
import {getSecondsTimeString, getTimeBetweenDates} from "@/utils/timeFormatters";


export class AdministrateCharacter implements ILoadModel {
  staticId: number;
  loading: boolean = false;
  private altMp: altMP;

  fullname?: string
  age?: number
  ip?: string
  login?: string
  socialClubId?: number
  inGameTime?: number
  accountInGameTime?: number
  lastConnectionTime?: number
  currentPosition?: {x: number, y: number, z: number}
  health?: number
  armor?: number
  adminLevel?: number
  vipLevel?: number

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

  get inGameTimeFormatted(): string {
    if (!this.inGameTime) return '0:0:0';

    return getSecondsTimeString(this.inGameTime as number);
  }

  get accountInGameTimeFormatted(): string {
    if (!this.accountInGameTime) return '0:0:0';

    return getSecondsTimeString(this.accountInGameTime as number);
  }

  get lastConnectionTimeFormatted(): string {
    if (!this.lastConnectionTime) return '0:0:0';

    return getTimeBetweenDates(new Date(this.lastConnectionTime as number * 1000), new Date());
  }
}
