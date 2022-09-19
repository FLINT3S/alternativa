import {defineStore} from "pinia";
import {ref} from "vue";
import type {GlobalTheme} from "naive-ui";
import {darkTheme} from "naive-ui";
import {altMP} from "@/connect/events/altMP";

export const useRootStore = defineStore('root', () => {
  const theme = ref<GlobalTheme | null>(darkTheme)

  const altMpRoot = ref(new altMP("Root", "1"))

  const isOverlayShown = ref(true)
  const isOverlayBackdropVisible = ref(true)
  const overlayBackdropTransition = ref(true)

  function changeTheme(newTheme: GlobalTheme | null | undefined = undefined) {
    if (newTheme === undefined) {
      theme.value = theme.value === null ? darkTheme : null
    } else {
      theme.value = newTheme
    }
  }

  function toggleOverlay() {
    isOverlayShown.value = !isOverlayShown.value
  }

  function setOverlay(value: boolean) {
    isOverlayShown.value = value
  }

  return {
    altMpRoot,
    theme,
    isOverlayShown,
    isOverlayBackdropVisible,
    overlayBackdropTransition,
    toggleOverlay,
    setOverlay,
    changeTheme
  }
})
