<template>
  <router-view v-slot="{Component}">
    <transition mode="out-in" name="fade">
      <component :is="Component"/>
    </transition>
  </router-view>
</template>

<script>
import {defineComponent} from 'vue';
import AltOverlay from "@/components/core/AltOverlay";
import {altMpAuth} from "@/modules/authorization/data/altMpAuth";

export default defineComponent({
  name: "authorization-root",
  data() {
    return {
      moduleName: "Authorization",
    }
  },
  components: {AltOverlay},
  mounted() {
    altMpAuth.on("AuthorizationInit", () => {
      this.$router.push("loader");
    });

    altMpAuth.on("LoginScreen", () => {
      this.$router.push("login")
    })
    altMpAuth.on("WelcomeScreen", () => {
      this.$router.push("welcome")
    })
  }
});
</script>

<style lang="scss">
@import "@/assets/style/animations/fade.scss";
</style>
