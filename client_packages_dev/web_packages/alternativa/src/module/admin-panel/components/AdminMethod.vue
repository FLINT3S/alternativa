<template>
  <n-thing :description="methodDescriptor.description" :title="methodDescriptor.name">
    <template #header-extra>
      <n-text class="text-x-small" depth="3" italic style="white-space: nowrap">{{ methodDescriptor.command }}</n-text>
    </template>
    <n-space vertical>
      <div
          v-for="param in methodDescriptor.params"
      >
        <n-input
            v-if="param.type === 'string'"
            :key="param.name"
            v-model:value="params[param.name]"
            :placeholder="param.name"
        />
        <n-input-number
            v-else-if="param.type === 'number' && param.name !== 'Статический ID игрока'"
            :key="param.name"
            v-model:value="params[param.name]"
            :placeholder="param.name"
        />
        <n-text class="text-small" depth="3">
          {{ param.description }}
        </n-text>
      </div>

      <n-space align="center">
        <n-button :disabled="!Object.values(params).every(v => v)" :loading="pendingEvent" secondary size="small"
                  type="primary" @click="onExecute">
          <template #icon>
            <svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path
                  d="M10.8 15.9l4.67-3.5c.27-.2.27-.6 0-.8L10.8 8.1a.5.5 0 0 0-.8.4v7c0 .41.47.65.8.4zM12 2C6.48 2 2 6.48 2 12s4.48 10 10 10s10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8s8 3.59 8 8s-3.59 8-8 8z"
                  fill="currentColor"></path>
            </svg>
          </template>
          Выполнить
        </n-button>

        <n-checkbox v-model:checked="waitAnswer" size="small">
          Ожидать ответ
        </n-checkbox>
      </n-space>
    </n-space>
  </n-thing>
</template>

<script lang="ts" setup>
import {NButton, NInput, NInputNumber, NSpace, NText, NThing, NCheckbox} from 'naive-ui'
import type {AdminDescriptorParam, AdminMethodDescriptor} from "@/module/admin-panel/data/AdminMethodDescriptor";
import type {Ref} from "vue";
import {ref} from "vue";
import {storeToRefs} from "pinia";
import {useAdminPlayersStore} from "@/store/adminPanelPlayers";
import {useAdminStore} from "@/store/adminPanel";

const {methodDescriptor} = defineProps<{ methodDescriptor: AdminMethodDescriptor }>()
const {selectedCharacter, pendingEvent, eventResult, waitAnswer} = storeToRefs(useAdminPlayersStore())
const {altMpAdmin} = storeToRefs(useAdminStore())

const defineParamValue = (param: AdminDescriptorParam) => {
  if (param.name === 'Статический ID игрока') {
    return selectedCharacter.value!.staticId
  }

  if (param.type === 'string') {
    return ''
  } else if (param.type === 'number') {
    return null
  }
}

type paramsType = {
  [key: string]: string | number
}

const params: Ref<any> = ref(methodDescriptor.params.reduce((acc, val) => ({
  ...acc,
  [val.name]: defineParamValue(val)
}), {}))

const onExecute = () => {
  pendingEvent.value = true

  if (waitAnswer.value) {
    altMpAdmin.value.triggerServerWithAnswerPending(methodDescriptor.command, ...Object.values(params.value as paramsType))
        .then((res) => {
          eventResult.value = JSON.stringify(res)
        })
        .catch(() => {
          eventResult.value = 'Ошибка выполнения'
        })
        .finally(() => {
          pendingEvent.value = false
        })
  } else {
    altMpAdmin.value.triggerServer(methodDescriptor.command, ...Object.values(params.value as paramsType))
    pendingEvent.value = false
  }
}
</script>

<style scoped>

</style>
