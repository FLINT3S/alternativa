export class CharacterData {
  public gender = 0
  public name: string
  public surname: string
  public age: number
  public faceFeatures: number[] = new Array(19).fill(0)
  public parents: {
    father: {
      name: string
      id: number
    },
    mother: {
      name: string
      id: number
    },
    similarity: number,
    skinSimilarity: number
  } = {
    father: {
      name: "Benjamin",
      id: 0
    },
    mother: {
      name: "Hannah",
      id: 21
    },
    similarity: 0.5,
    skinSimilarity: 0.5
  }

  get dto(): string {
    const dto = {
      name: this.name,
      surname: this.surname,
      age: this.age,
      gender: this.gender,
      faceFeatures: this.faceFeatures,
      motherId: this.parents.mother.id,
      fatherId: this.parents.father.id,
      similarity: Math.abs(this.parents.similarity - 1),
      skinSimilarity: Math.abs(this.parents.skinSimilarity - 1),
    }

    return JSON.stringify(dto)
  }

  setCommonInfo(commonInfo: string) {
    const dto = JSON.parse(commonInfo)

    this.name = dto.name
    this.surname = dto.surname
    this.age = dto.age
  }
}
