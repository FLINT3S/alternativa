<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <router-view v-slot="{Component}">
      <transition name="fade" mode="out-in">
        <component :is="Component"/>
      </transition>
    </router-view>
  </alt-overlay>
</template>

<script>
import {defineComponent} from 'vue';
import AltOverlay from "@/components/core/AltOverlay";
import {openOverlayMixin} from "@/mixins/openOverlayMixin";

export default defineComponent({
  name: "authorization-root",
  mixins: [openOverlayMixin],
  components: {AltOverlay},
  created() {
    this.$router.push("/loading");

    this.$altMp.on("LoginScreen", () => {
      this.$router.push("/login")
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
