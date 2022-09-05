<template>
  <router-view v-slot="{Component}">
    <alt-overlay :is-overlay-open="isOverlayOpen" :overlay-backdrop="overlayBackdrop">
      <transition mode="out-in" name="fade">
        <component :is="Component"/>
      </transition>
    </alt-overlay>
  </router-view>
  <info-hud/>
</template>

<script>
import {altMP} from "@/connect/events/altMP";
import {defineComponent} from "vue";
import AltOverlay from "@/components/core/AltOverlay";
import InfoHud from "@/modules/debug-hud/InfoHud";

export default defineComponent({
  name: "AltRoot",
  components: {InfoHud, AltOverlay},
  data() {
    return {
      altMpRoot: new altMP("Root", "1"),
      isOverlayOpen: true,
      overlayBackdrop: true
    }
  },
  provide: {
    alrMpRoot: () => this.altMpRoot
  },
  mounted() {
    this.altMpRoot.on("GoTo", (location) => {
      this.$router.push(location);
    });
    this.altMpRoot.on("onOpenOverlay", this.onOpenOverlay);
    this.altMpRoot.on("onCloseOverlay", this.onCloseOverlay);
    this.altMpRoot.on("onToggleOverlay", this.onToggleOverlay);
    this.altMpRoot.on("turnOnBackdrop", () => this.overlayBackdrop = true);
    this.altMpRoot.on("turnOffBackdrop", () => this.overlayBackdrop = false);
  },
  methods: {
    onOpenOverlay: function () {
      this.isOverlayOpen = true;
    },
    onCloseOverlay: function () {
      this.isOverlayOpen = false;
    },
    onToggleOverlay: function () {
      this.isOverlayOpen = !this.isOverlayOpen;
    }
  }
})
</script>

<style scoped>

</style>
