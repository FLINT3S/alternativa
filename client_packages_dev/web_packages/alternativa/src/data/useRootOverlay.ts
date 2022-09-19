import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";
import type {Ref} from "vue";
import {onMounted} from "vue";


export default function useRootOverlay(): { isOverlayShown: Ref<boolean>, isOverlayBackdropVisible: Ref<boolean>, overlayBackdropTransition: Ref<boolean> } {
  const {altMpRoot, isOverlayBackdropVisible, isOverlayShown, overlayBackdropTransition} = storeToRefs(useRootStore())
  const {toggleOverlay, setOverlay} = useRootStore()

  altMpRoot.value.on("onOpenOverlay", setOverlay.bind(null, true))
  altMpRoot.value.on("onCloseOverlay", setOverlay.bind(null, false))
  altMpRoot.value.on("onToggleOverlay", toggleOverlay)

  altMpRoot.value.on("turnOnBackdrop", () => isOverlayBackdropVisible.value = true)
  altMpRoot.value.on("turnOffBackdrop", () => isOverlayBackdropVisible.value = false)

  return {
    isOverlayBackdropVisible,
    overlayBackdropTransition,
    isOverlayShown
  }
}
