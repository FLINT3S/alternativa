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
  methods: {
    onAuthInit() {
      this.$router.push("loader");
    },
    onLoginScreen() {
      this.$router.push("login")
    },
    onWelcomeScreen() {
      this.$router.push("welcome")
    }
  },
  mounted() {
    altMpAuth.on("AuthorizationInit", this.onAuthInit);
    altMpAuth.on("LoginScreen", this.onLoginScreen)
    altMpAuth.on("WelcomeScreen", this.onWelcomeScreen)
  }
});
</script>

<style lang="scss">
@import "@/assets/style/animations/fade.scss";
</style>
