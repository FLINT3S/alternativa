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
}
