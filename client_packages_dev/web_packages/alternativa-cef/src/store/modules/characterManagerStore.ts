import {CharacterData} from "@/modules/character-manager/data/CharacterData";

export const characterManagerStore = {
  state: () => ({
    characterData: new CharacterData()
  }),
  getters: {
    characterData: (state: any): CharacterData => state.characterData
  },
}
