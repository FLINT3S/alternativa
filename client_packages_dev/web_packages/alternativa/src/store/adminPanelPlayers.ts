import {defineStore, storeToRefs} from "pinia";
import type {Ref} from "vue";
import {computed, ref, watch} from "vue";
import type {AdminMethodsGroup} from "@/module/admin-panel/data/AdminMethodDescriptor";
import type {OnlineCharacters} from "@/module/admin-panel/data/types";
import type {AdministrateCharacter} from "@/module/admin-panel/data/AdministrateCharacter";
import {useAdminStore} from "@/store/adminPanel";

// export const mockPlayers = [
//   {
//     staticId: 1,
//     fullname: "John Doe",
//   },
//   {
//     staticId: 2,
//     fullname: "Alex Smith",
//   },
//   {
//     staticId: 3,
//     fullname: "Bob Marley",
//   }
// ]

export const useAdminPlayersStore = defineStore('adminPlayers', () => {
  const {altMpAdmin, availableMethods} = storeToRefs(useAdminStore())

  const availablePlayersMethods: Ref<AdminMethodsGroup> = ref(availableMethods.value.players)
  const playersMethodsFilter: Ref<string> = ref('')
  const fullOnlineCharactersList: Ref<OnlineCharacters> = ref([])
  const onlineCharactersListFilter: Ref<string> = ref('')
  const selectedCharacter: Ref<AdministrateCharacter | null> = ref(null)
  const pendingEvent: Ref<boolean> = ref(false)
  const eventResult: Ref<string | null> = ref(null)
  const waitAnswer: Ref<boolean> = ref(false)

  const onlineCharactersList = computed(() => {
    return fullOnlineCharactersList.value.filter((character) =>
      (character.fullname + character.staticId).toLowerCase().includes(onlineCharactersListFilter.value.toLowerCase())
    )
  })

  function loadOnlineCharactersList() {
    altMpAdmin.value.triggerServerWithAnswerPending("GetOnlineCharacters")
      .then(([characters]) => {
        fullOnlineCharactersList.value = JSON.parse(characters as string)
      })
  }

  const expandedCollapseNames: Ref<string[]> = ref([] as string[])

  watch(playersMethodsFilter, (newVal) => {
    if (newVal === '') {
      expandedCollapseNames.value = []
    }
    if (newVal.length > 2) {
      expandedCollapseNames.value = Object.keys(availablePlayersMethods.value)
    }
  })

  return {
    availablePlayersMethods,
    playersMethodsFilter,
    fullOnlineCharactersList,
    onlineCharactersListFilter,
    selectedCharacter,
    onlineCharactersList,
    loadOnlineCharactersList,
    expandedCollapseNames,
    pendingEvent,
    eventResult,
    waitAnswer
  }
})
