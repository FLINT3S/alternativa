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
      Почта необходима для восстановления пароля и дополнительной идентификации. Мы не рассылаем спам и не передаем данные третьим лицам
    </n-p>
    <n-space vertical>
      <n-form-item
          class="custom-feedback show-feedback"
          label="Почта"
          path="email"
      >
        <n-auto-complete
            v-model:value="registrationData.email"
            :get-show="getShowOptions"
            :input-props="{autocomplete: 'disabled'}"
            :options="emailOptions"
            placeholder="Электронная почта"
            @input="onEmailInput"
            :loading="registrationData.emailCheck.loading"
        />
      </n-form-item>
      <n-checkbox
          class="mb-2"
          v-model:checked="registrationData.promoAgreement"
      >
        Хочу получать на почту новости сервера, акции и специальные предложения
      </n-checkbox>
    </n-space>

    <n-button
        class="mt-auto"
        block
        size="large"
        type="primary"
        :disabled="!registrationData.validate.fields.email.isValid"
        @click="onSubmit"
    >
      Дальше
    </n-button>
  </n-form>
</template>

<script lang="ts" setup>
import {NAutoComplete, NForm, NFormItem, NSpace, NCheckbox, NP, NButton} from "naive-ui";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";
import type {Ref} from "vue";
import {computed, reactive} from "vue";
import {debounce} from "@/data/debounce";
import type {altMP} from "@/connect/events/altMP";

const {
  registrationData,
  altMpAuth
}: { registrationData: Ref<RegistrationDTO>, altMpAuth: Ref<altMP> } = storeToRefs(useAuthStore())

const debounceEmailCheck = debounce((email: string) => {
  registrationData.value.emailCheck.loading = true
  altMpAuth.value.triggerServerWithAnswerPending('CheckEmail', email)
      .then(([result]) => {
        registrationData.value.emailCheck.loading = false
        registrationData.value.emailCheck.available = result === false
        registrationData.value.emailCheck.error = false
      })
      .catch(() => {
        registrationData.value.emailCheck.loading = false
        registrationData.value.emailCheck.available = false
        registrationData.value.emailCheck.error = true
      })
}, 500)

const getShowOptions = (value: string) => {
  return value.includes('@')
}

const emailOptions = computed(() => {
  const suggestions = ['@gmail.com', '@mail.ru', '@yandex.ru', '@outlook.com']
  const domainPart = registrationData.value.email.split('@')[1] || ""

  return suggestions.filter(s => s.includes(domainPart)).map((suffix) => {
    const prefix = registrationData.value.email.split('@')[0]
    return {
      label: prefix + suffix,
      value: prefix + suffix
    }
  })
})

const onEmailInput = (value: string) => {
  if (value.includes('@')) {
    debounceEmailCheck(value)
  }
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
