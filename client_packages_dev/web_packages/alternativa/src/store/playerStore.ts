import {defineStore, storeToRefs} from "pinia";
import {CurrentPlayer} from "@/data/CurrentPlayer";
import type {Ref} from "vue";
import {ref} from "vue";
import {useRootStore} from "@/store/index";


export const usePlayerStore = defineStore('player', () => {
  const {altMpRoot} = storeToRefs(useRootStore())

  const player: Ref<CurrentPlayer> = ref(new CurrentPlayer())

  function registerPlayerListeners() {
    altMpRoot.value.on("SendPlayerMainInfo", (playerMainInfo) => {
      player.value.socialClubId = playerMainInfo.socialClubId
      player.value.socialClubName = playerMainInfo.socialClubName
    })

    altMpRoot.value.on("SendCurrentPosition", (position) => {
      player.value.position = JSON.parse(position)
    })
  }

  function requestPlayerPosition() {
    altMpRoot.value.triggerClient("GetCurrentPosition")
  }

  function requestPlayerPositionAsync() {
    return new Promise((resolve) => {
      const callback = (position: any) => {
        resolve(JSON.parse(position))
        altMpRoot.value.off("SendCurrentPosition", callback)
      }

      altMpRoot.value.on("SendCurrentPosition", (position) => callback(position))
      altMpRoot.value.triggerClient("GetCurrentPosition")
    })
  }

  function requestPlayerMainInfo() {
    altMpRoot.value.triggerClient("GetPlayerMainInfo")
  }

  return {
    player,
    registerPlayerListeners,
    requestPlayerPosition,
    requestPlayerPositionAsync
  }
})
