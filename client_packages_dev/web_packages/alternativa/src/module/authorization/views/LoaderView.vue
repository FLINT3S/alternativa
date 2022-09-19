<template>
  <div class="text-center">
    <object :data="animatedLogo" type="image/svg+xml"></object>
    <n-h2 :style="longLoadingHint ? {opacity: 1, height: '100px'} : {opacity: 0, height: 0}"
         class="loading-timeout transition-default mx-auto lh-1" tag="div">
      Игра слишком долго грузится, возможно, что-то пошло не так...<br>
      Если игра не загрузится в ближайшие несколько секунд - попробуй перезайти
    </n-h2>
  </div>
</template>

<script lang="ts" setup>
import type {Ref} from "vue";
import {onDeactivated, ref} from "vue";

import {NH2} from "naive-ui"

import animatedLogo from "@/assets/logo/animatedLoadingAlternativaLogo.svg";

const longLoadingTimeout: Ref = ref(null);
const longLoadingHint = ref(false);

longLoadingTimeout.value = setTimeout(() => {
  longLoadingHint.value = true;
}, 12000)

onDeactivated(() => {
  clearTimeout(longLoadingTimeout.value)
})
</script>
