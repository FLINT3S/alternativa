import {fathers, mothers} from "@/modules/character-manager/data/creatorData";
import {getRandomFloat} from "@/utils/randoms";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";
import {helpers, maxValue, minLength, minValue, required} from "@vuelidate/validators";

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

  randomizeAppearance(forceParents = true, forceFeatures = true) {
    this.randomizeParents(forceParents)
    this.randomizeFeatures(Array.from(Array(19).keys()), forceFeatures)
  }

  randomizeParents(forceUpdate = false) {
    this.parents.mother = mothers.getRandomElement()
    this.parents.father = fathers.getRandomElement()
    this.parents.similarity = getRandomFloat(0, 1, 2)
    this.parents.skinSimilarity = getRandomFloat(0, 1, 2)

    if (forceUpdate) {
      this.updateParentsData()
    }
  }

  randomizeFeatures(features: number[], forceUpdate = false) {
    features.forEach((index) => {
      this.faceFeatures[index] = getRandomFloat(-1, 1, 2)
    })

    if (forceUpdate) {
      this.updateFaceFeaturesData()
    }
  }

  updateParentsData() {
    altMpCM.triggerClient("UpdateParents", JSON.stringify(this.parents))
  }

  updateFaceFeaturesData() {
    altMpCM.triggerClient("UpdateFaceFeatures", JSON.stringify(this.faceFeatures))
  }

  public static validators = {
    name: {
      required: helpers.withMessage("Введите имя", required),
      minLength: helpers.withMessage("Имя должно быть больше 2 букв", minLength(3)),
    },
    surname: {
      required: helpers.withMessage("Введите фамилию", required),
      minLength: helpers.withMessage("Фамилия должна быть больше 2 букв", minLength(3)),
    },
    age: {
      required: helpers.withMessage("Введите возраст", required),
      min: helpers.withMessage("Минимальный возраст - 18", minValue(18)),
      max: helpers.withMessage("Максимальный возраст - 120", maxValue(120))
    }
  }

  get commonInfo() {
    return JSON.stringify({
      name: this.name,
      surname: this.surname,
      age: this.age
    })
  }
}
