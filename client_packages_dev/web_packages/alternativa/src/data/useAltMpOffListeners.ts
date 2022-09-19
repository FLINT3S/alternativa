import {onUnmounted} from "vue";

export const useAltMpOffListeners = (...offCallbacks: (() => void)[]) => {
  onUnmounted(() => {
    offCallbacks.forEach(offCallback => offCallback())
  })
}
