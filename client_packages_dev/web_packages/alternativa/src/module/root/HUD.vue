<template>
  <transition :name="HUDTransition ? 'fade' : ''">
    <div class="hud__wrapper" v-if="isHUDShown">
      <div class="top-info d-flex">
        <div>
          {{}}
        </div>
        <img :src="fullLogoImage" alt="" class="hud-logo">
      </div>
    </div>
  </transition>
</template>

<script setup lang="ts">
import fullLogoImage from '@/assets/logo/fullLogo.svg'
import useHUD from "@/data/useHUD";

const {isHUDShown, HUDTransition} = useHUD()

</script>

<style scoped>
.hud__wrapper {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: -2;
}

html[data-dev="true"] .hud__wrapper {
  background: url("@/assets/dev_bg.png") no-repeat center center !important;
  background-size: cover;
}

.top-info {
  position: absolute;
  top: 15px;
  right: 15px;
}

.hud-logo {
  width: 5vw;
}
</style>
