<template>
  <div class="root">
  </div>
</template>

<script lang="ts" setup>
import {useMessage} from "naive-ui";
import {useRootStore} from "@/store";
import {storeToRefs} from "pinia";

const naiveMessage = useMessage()
const {altMpRoot} = storeToRefs(useRootStore())

altMpRoot.value.on("ShowMessage", (message: string, ...params: any[]) => {
  naiveMessage.info(message)
})

altMpRoot.value.onServer("ShowMessage", (message: string, status: number) => {
  console.log(status)

  if (status === 0) {
    naiveMessage.error(message)
  } else if (status === 1) {
    naiveMessage.warning(message)
  } else if (status === 2) {
    naiveMessage.success(message)
  } else {
    naiveMessage.info(message)
  }
})

</script>

<style scoped>

</style>
