import {defineStore} from "pinia";
import {altMP} from "@/connect/events/altMP";
import {ref} from "vue";
import type {Ref} from "vue";
import type {Character} from "@/data/Character";
import {CharacterData} from "@/module/character-manager/data/CharacterData"

export const useCharacterManagerStore = defineStore('characterManager', () => {
  const altMpCm = ref(new altMP('CharacterManager', '1'))
  const ownCharacters = ref<Array<Character>>([])
  const characterCreationData: Ref<CharacterData> = ref(new CharacterData())

  return {
    altMpCm,
    characterCreationData,
    ownCharacters
  }
})
