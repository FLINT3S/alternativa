<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <transition name="fade">
      <router-view/>

    </transition>
  </alt-overlay>
</template>

<script>
import { defineComponent } from 'vue';
import AltOverlay from "@/components/AltOverlay";
import {openOverlayMixin} from "@/mixins/openOverlayMixin";

export default defineComponent({
  name: "authorization-root",
  mixins: [openOverlayMixin],
  components: {AltOverlay},
  created() {
    this.$router.push("/loader");

    this.$altMp.on("LoginScreen", () => {
      this.$router.push("/")
    })
    this.$altMp.on("WelcomeScreen", () => {
      this.$router.push("/welcome")
    })
  }
});
</script>

<style lang="scss">
@import "@/assets/style/animations/fade.scss";
</style>
