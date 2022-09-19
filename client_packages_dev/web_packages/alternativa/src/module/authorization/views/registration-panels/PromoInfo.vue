<template>
  <n-form
      :model="registrationData"
      :rules="registrationData.rules"
      class="text-start h-100 d-flex flex-column"
      label-placement="left"
      label-width="auto"
      require-mark-placement="right-hanging"
      size="medium"
  >
    <n-p depth="3" class="text-small">
      Укажи промокод или реферальный код, чтобы получить бонусы на старте. Можешь найти их в наших соцсетях, в
      видеороликах или попросить у друзей
    </n-p>

    <n-space vertical>
      <n-form-item
          label="Промокод"
          path="promocode"
      >
        <n-input
            v-model:value="registrationData.promocode"
            placeholder="Промокод"
        />
      </n-form-item>
    </n-space>

    <n-button
        block
        class="mt-auto"
        size="large"
        type="primary"
        @click="onSubmit"
    >
      Дальше
    </n-button>
  </n-form>
</template>

<script lang="ts" setup>
import {NButton, NForm, NFormItem, NInput, NP, NSpace} from "naive-ui";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";
import type {Ref} from "vue";
import type {altMP} from "@/connect/events/altMP";

const {
  registrationData,
  altMpAuth
}: { registrationData: Ref<RegistrationDTO>, altMpAuth: Ref<altMP> } = storeToRefs(useAuthStore())

const emit = defineEmits<{
  (e: 'next-step'): void
}>()

const onSubmit = () => {
  emit('next-step')
}
</script>

<style scoped>

</style>
