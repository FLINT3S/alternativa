<template>
  <div class="d-flex flex-column align-items-center">
    <router-view v-slot="{Component}">
      <transition mode="out-in" name="fade">
        <component :is="Component"/>
      </transition>
    </router-view>

    <!--      TODO: Социальные кнопки с модалкой -->
  </div>
</template>

<script lang="ts" setup>
import {useRouter} from "vue-router";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import {useAltMpOffListeners} from "@/data/useAltMpOffListeners";

const router = useRouter();
const {altMpAuth} = storeToRefs(useAuthStore())

const onAuthInit = () => {
  router.push("loader");
}
const onLoginScreen = () => {
  router.push("login")
}
const onWelcomeScreen = () => {
  router.push("welcome")
}

useAltMpOffListeners(
    altMpAuth.value.on("AuthorizationInit", onAuthInit),
    altMpAuth.value.on("LoginScreen", onLoginScreen),
    altMpAuth.value.on("WelcomeScreen", onWelcomeScreen)
)
</script>

<style lang="scss">
</style>
