<template>
  <transition :name="overlayBackdropTransition ? 'fade' : ''">
    <div class="overlay-backdrop" v-if="overlayBackdrop && isOverlayOpen">
    </div>
  </transition>
  <transition name="slide-down">
    <main class="overlay-main" :class="!isOverlayOpen && 'pointer-none'" :style="contentClass" v-if="isOverlayOpen">
      <slot></slot>
    </main>
  </transition>
</template>

<script lang="ts">
// TODO: Refactor to composition API
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltOverlay",
  props: {
    isOverlayOpen: {
      type: Boolean,
      default: false,
    },
    overlayBackdrop: {
      type: Boolean,
      default: true,
    },
    overlayBackdropTransition: {
      type: Boolean,
      default: true
    },
    contentAlign: {
      type: String,
      default: "center",
    },
  },
  computed: {
    contentClass() {
      const res = {
        justifyContent: this.contentAlign,
        alignItems: this.contentAlign,
      }

      switch (this.contentAlign) {
        case "center":
          res.justifyContent = "center";
          res.alignItems = "center";
          break;
      }

      return res
    },
  }
})
</script>

<style scoped lang="scss">
@import '@/assets/style/animations.scss';

.overlay-backdrop {
  height: 100vh;
  width: 100vw;
  z-index: -1;
  position: absolute;
  background-color: var(--backdrop-color);
}

.overlay-main {
  position: absolute;
  height: 100vh;
  width: 100vw;
  z-index: 1;
  transition-delay: .1s;
  display: flex;
}

.overlay-main.pointer-none *{
  pointer-events: none;
}
</style>
