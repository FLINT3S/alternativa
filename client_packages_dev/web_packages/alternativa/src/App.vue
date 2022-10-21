<template>
  <n-config-provider :date-locale="dateRuRU" :locale="locale" :theme="theme" :theme-overrides="themeOverrides">
    <n-global-style/>
    <n-message-provider>
      <router-view v-slot="{ Component }">
        <alt-overlay :is-overlay-open="isOverlayShown" :overlay-backdrop="isOverlayBackdropVisible"
                     :overlay-backdrop-transition="overlayBackdropTransition">
          <transition mode="out-in" name="fade">
            <component :is="Component"/>
          </transition>
        </alt-overlay>
      </router-view>
      <root/>

      <HUD/>
    </n-message-provider>

    <debug-drawer/>

  </n-config-provider>
</template>


<script lang="ts" setup>
import {ref} from "vue";
import {useRouter} from "vue-router";
import {storeToRefs} from "pinia";

import type {NLocale} from 'naive-ui'
import {dateRuRU, NConfigProvider, NGlobalStyle, NMessageProvider, ruRU} from 'naive-ui'

import themeOverrides from './assets/theme/naive-ui-theme-overrides.json'
import {useRootStore} from "@/store"

import AltOverlay from "@/components/AltOverlay.vue"
import DebugDrawer from "@/DebugDrawer.vue";
import Root from "@/module/root/Root.vue";
import HUD from "@/module/root/HUD.vue";

import useRootOverlay from "@/data/useRootOverlay"
import {useDeathAndRebornStore} from "@/store/deathAndReborn";
import {usePlayerStore} from "@/store/playerStore";

const {theme, altMpRoot} = storeToRefs(useRootStore())
const {registerDeathListeners} = useDeathAndRebornStore()
const {registerPlayerListeners} = usePlayerStore()

const router = useRouter()
altMpRoot.value.on("GoTo", (location) => {
  router.push(location);
});

registerDeathListeners()
registerPlayerListeners()

const locale = ref<NLocale>(ruRU)
const {isOverlayShown, isOverlayBackdropVisible, overlayBackdropTransition} = useRootOverlay()

if (import.meta.env.MODE === "development") {
  document.documentElement.setAttribute("data-dev", "true")
}
</script>
