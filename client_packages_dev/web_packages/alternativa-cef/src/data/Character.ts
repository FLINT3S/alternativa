import {BaseModel} from "@/data/BaseModel";

interface ICharacter {
  firstName: string
  lastName: string
  age: number
  inGameTime: number
  guid: string
  staticId: number
}

export class Character extends BaseModel<ICharacter>{
  firstName: string
  lastName: string
  age: number
  inGameTime: number
  guid: string
  staticId: number

  constructor(rawObject: ICharacter) {
    super(rawObject)
    Object.assign(this, rawObject)
  }

  get inGameTimeFormatted(): string {
    let minutes = this.inGameTime / 60
    const hours = Math.floor(minutes / 60)
    minutes = Math.floor(minutes - hours * 60)
    return `${hours.toString().padStart(2, "0")}:${minutes.toString().padStart(2, "0")}`
  }
}
