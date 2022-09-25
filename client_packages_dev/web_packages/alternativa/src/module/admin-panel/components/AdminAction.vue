<template>
  <n-list-item style="padding-left: 12px;">
    <n-thing :description="actionDescriptor.description" :title="actionDescriptor.name">
      <div
          v-for="(param, index) in actionDescriptor.params"
      >
        <n-input
            v-if="param.type === 'string'"
            :key="param.name"
            v-model:value="params[index]"
            :placeholder="param.name"
        />
        <n-input-number
            v-else
            :key="param.name"
            v-model:value="params[index]"
            :placeholder="param.name"
        />
        <n-text class="text-small" depth="3">
          {{ param.description }}
        </n-text>
      </div>
    </n-thing>

    <template #suffix>
      <n-button secondary size="small" type="primary" @click="onExecute">
        <template #icon>
          <n-icon>
            <svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
              <path
                  d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10s10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8s8 3.59 8 8s-3.59 8-8 8zm-2-3.5l6-4.5l-6-4.5z"
                  fill="currentColor"></path>
            </svg>
          </n-icon>
        </template>
      </n-button>
    </template>
  </n-list-item>
</template>

<script lang="ts" setup>
import {NButton, NIcon, NInput, NListItem, NThing, NInputNumber, NText} from 'naive-ui'
import type {AdminActionDescriptor} from "@/module/admin-panel/data/AdminActionDescriptor";
import {ref} from "vue";
import type {Ref} from "vue";

const {actionDescriptor} = defineProps<{ actionDescriptor: AdminActionDescriptor }>()

const params: Ref<Array<any>> = ref(actionDescriptor.params.map(param => ''))

const onExecute = () => {
  console.log(params.value)
}
</script>

<style scoped>

</style>
