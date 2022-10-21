import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";
import type {Ref} from "vue";

export default function useHUD(): { isHUDShown: Ref<boolean>, HUDTransition: Ref<boolean> } {
  const {altMpRoot, isHUDShown, HUDTransition} = storeToRefs(useRootStore())

  altMpRoot.value.on("ShowHUD", () => {
    isHUDShown.value = true
  })

  altMpRoot.value.on("HideHUD", () => {
    isHUDShown.value = false
  })

  altMpRoot.value.on("SetHUDTransition", (value: boolean) => {
    HUDTransition.value = value
  })

  return {
    isHUDShown, HUDTransition
  }
}
