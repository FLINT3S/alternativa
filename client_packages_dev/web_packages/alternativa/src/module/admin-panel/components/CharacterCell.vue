<template>
  <n-list-item>
    <slot/>
    <template #suffix>
      <span style="white-space: nowrap">
        [{{staticId}}]
      </span>
    </template>
  </n-list-item>
</template>

<script lang="ts" setup>
import {NListItem} from 'naive-ui'

const {staticId} = defineProps<{ staticId?: string | number }>()
</script>

<style scoped>

</style>
