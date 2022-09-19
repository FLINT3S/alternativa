<template>
  <n-card class="width-sm text-center">
    <alt-logo/>

    <n-h1>Привет!</n-h1>

    <n-h3 style="line-height: 1.2">
      Добро пожаловать на Alternativa Role Play!
      <br>
      Мы рады видеть тебя в рядах наших игроков, и сделаем всё, чтобы ты получил
      лучший игровой опыт!
    </n-h3>

    <n-button block size="large" type="primary" @click="onStart">
      Начать играть
    </n-button>
  </n-card>
</template>

<script lang="ts" setup>
import {NButton, NCard, NH1, NH3} from 'naive-ui'
import AltLogo from "@/components/AltLogo.vue";
import {useRouter} from "vue-router";

const router = useRouter()

const onStart = () => {
  router.push('registration')
}
</script>

<style scoped>

</style>
