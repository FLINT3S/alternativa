<template>
  <n-card>
    <n-date-picker>

    </n-date-picker>
    <n-button type="primary" @click="theme = null">
      Кнопка
    </n-button>
  </n-card>
</template>

<script lang="ts" setup>
import {NButton, NCard, NDatePicker} from 'naive-ui'
import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";

const {theme} = storeToRefs(useRootStore())
</script>

<style>

</style>
