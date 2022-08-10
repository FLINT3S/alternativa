<template>
  <transition name="fade">
    <div class="overlay-backdrop" v-if="isOverlayOpen">
    </div>
  </transition>
  <transition name="slide-down">
    <main class="overlay-main" :style="contentClass" v-if="isOverlayOpen">
      <slot></slot>
    </main>
  </transition>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltOverlay",
  props: {
    isOverlayOpen: {
      type: Boolean,
      default: false,
    },
    contentAlign: {
      type: String,
      default: "center",
    },
  },
  computed: {
    contentClass() {
      const res = {}

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
@import "src/assets/style/animations/slide-down.scss";
@import "src/assets/style/animations/fade.scss";

.overlay-backdrop {
  height: 100vh;
  width: 100vw;
  z-index: -1;
  position: absolute;
  background-color: var(--overlay-backdrop);
}

.overlay-main {
  position: absolute;
  height: 100vh;
  width: 100vw;
  z-index: 1;
  transition-delay: .1s;
  display: flex;
}
</style>
