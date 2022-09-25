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
    <n-p class="text-small" depth="3">
      Почта необходима для восстановления пароля и дополнительной идентификации. Мы не рассылаем спам и не передаем
      данные третьим лицам
    </n-p>
    <n-space vertical>
      <n-form-item
          class="custom-feedback show-feedback"
          label="Почта"
          path="email"
      >
        <n-input
            ref="emailRef"
            v-model:value="registrationData.email"
            :input-props="{autocomplete: 'disabled'}"
            :loading="registrationData.emailCheck.loading"
            :options="emailOptions"
            blur-after-select
            placeholder="Электронная почта"
            @update:value="onEmailInput"
        />
      </n-form-item>
      <n-checkbox
          v-model:checked="registrationData.promoAgreement"
          class="mb-15"
      >
        Хочу получать на почту новости сервера, акции и специальные предложения
      </n-checkbox>
    </n-space>

    <n-button
        :disabled="!registrationData.validate.fields.email.isValid || registrationData.emailCheck.loading || !registrationData.emailCheck.available"
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
import type {FormItemInst} from "naive-ui";
import {NButton, NCheckbox, NForm, NFormItem, NInput, NP, NSpace} from "naive-ui";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";
import type {Ref} from "vue";
import {computed, ref} from "vue";
import {debounce} from "@/data/debounce";
import type {altMP} from "@/connect/events/altMP";

const {
  registrationData,
  altMpAuth
}: { registrationData: Ref<RegistrationDTO>, altMpAuth: Ref<altMP> } = storeToRefs(useAuthStore())

const emailRef = ref<FormItemInst | null>(null)

const debounceEmailCheck = debounce((email: string) => {
  altMpAuth.value.triggerServerWithAnswerPending('CheckEmail', email)
      .then(([result]) => {
        registrationData.value.emailCheck.available = result === false
        registrationData.value.emailCheck.error = false
      })
      .catch(() => {
        registrationData.value.emailCheck.available = false
        registrationData.value.emailCheck.error = true
      })
      .finally(() => {
        registrationData.value.emailCheck.loading = false
        // @ts-ignore
        emailRef.value?.blur()
        // @ts-ignore
        emailRef.value?.focus()
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
    registrationData.value.emailCheck.loading = true
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
