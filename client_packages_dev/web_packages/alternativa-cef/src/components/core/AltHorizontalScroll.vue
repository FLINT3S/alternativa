<template>
  <div ref="scroller" class="d-flex alt-carousel">
    <slot></slot>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltHorizontalScroll",
  methods: {
    scrollHorizontally(e) {
      e = window.event || e;
      var delta = Math.max(-1, Math.min(1, (e.wheelDelta || -e.detail)));
      this.$refs.scroller.scrollLeft -= (delta * 50)
      e.preventDefault();
    }
  },
  mounted() {
    this.$refs.scroller.addEventListener('mousewheel', this.scrollHorizontally, false);
  },
  deactivated() {
    this.$refs.scroller.removeEventListener('mousewheel', this.scrollHorizontally, false);
  }
})
</script>

<style scoped>
.alt-carousel {
  overflow-x: auto;
  padding-right: 12px;
  padding-bottom: 2px;
}

.alt-carousel::-webkit-scrollbar {
  height: 4px;
  transition: all 0.3s ease;
}
</style>
