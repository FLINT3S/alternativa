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
    <n-space vertical>
      <n-checkbox
          v-model:checked="registrationData.rulesAgreement"
      >
        Подтверждаю ознакомление с
        <n-a @click="showTermsModal">правилами</n-a>
        сервера и соглашаюсь с ними
      </n-checkbox>
      <n-checkbox
          v-model:checked="registrationData.privacyAgreement"
      >
        Соглашаюсь с
        <n-a @click="showPrivacyModal">политикой конфиденциальности</n-a>
        сервера
      </n-checkbox>
      <n-checkbox
          v-model:checked="registrationData.ageAgreement"
      >
        Подтверждаю, что мне исполнилось 18 лет
      </n-checkbox>
    </n-space>

    <n-modal v-model:show="showModal" class="width-md" closable preset="card" transform-origin="center">
      <template #header>
        {{ modalHeader }}
      </template>

      {{ modalText }}
    </n-modal>

    <n-button
        :disabled="!registrationData.validate.isValid ||
        !registrationData.ageAgreement ||
        !registrationData.privacyAgreement ||
        !registrationData.rulesAgreement"
        block
        class="mt-auto"
        size="large"
        type="primary"
        @click="onSubmit"
    >
      Создать аккаунт
    </n-button>
  </n-form>
</template>

<script lang="ts" setup>
import {NA, NButton, NCheckbox, NForm, NModal, NSpace} from "naive-ui";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";
import type {Ref} from "vue";
import {ref} from "vue";
import type {altMP} from "@/connect/events/altMP";

const {
  registrationData,
  altMpAuth
}: { registrationData: Ref<RegistrationDTO>, altMpAuth: Ref<altMP> } = storeToRefs(useAuthStore())

const modalHeader = ref('')
const modalText = ref('')
const showModal = ref(false)

const showTermsModal = () => {
  modalHeader.value = 'Правила сервера'
  modalText.value = 'Текст правил'
  showModal.value = true
}

const showPrivacyModal = () => {
  modalHeader.value = 'Политика конфиденциальности'
  modalText.value = 'Текст политики конфиденциальности'
  showModal.value = true
}

const emit = defineEmits<{
  (e: 'next-step'): void
}>()

const onSubmit = () => {
  emit('next-step')
}
</script>

<style scoped>

</style>
