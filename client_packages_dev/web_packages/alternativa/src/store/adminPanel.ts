import {defineStore} from "pinia";
import {altMP} from "@/connect/events/altMP";
import {computed, ref} from "vue";

export const mockPlayers = [
  {
    staticId: 1,
    fullname: "John Doe",
    inGameTime: 1000,
    age: 20
  },
  {
    staticId: 2,
    fullname: "Alex Smith",
    inGameTime: 123,
    age: 30
  },
  {
    staticId: 3,
    fullname: "Bob Marley",
    inGameTime: 432,
    age: 40
  }
]

export const useAdminStore = defineStore('admin', () => {
  const altMpAdmin = ref(new altMP("AdminPanel", "1"))
  const fullOnlineCharactersList = ref(mockPlayers)
  const onlineCharactersListFilter = ref('')

  const onlineCharactersList = computed(() => {
    return fullOnlineCharactersList.value.filter((character) => {
      return character.fullname.toLowerCase().includes(onlineCharactersListFilter.value.toLowerCase()) ||
        character.staticId.toString().includes(onlineCharactersListFilter.value)
    })
  })

  return {
    altMpAdmin,
    fullOnlineCharactersList,
    onlineCharactersList,
    onlineCharactersListFilter
  }
})
