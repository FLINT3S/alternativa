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
      <n-form-item
          :class="{'show-feedback': registrationData.validate.fields.login.touchedInvalid ||
          (registrationData.loginCheck.available === false && registrationData.loginCheck.loading === false && registrationData.validate.fields.login.touched)}"
          class="custom-feedback"
          label="Логин"
          path="login"
          ref="loginInputRef"
      >
        <n-input
            v-model:value="registrationData.login"
            :allow-input="loginAllowInput"
            :loading="registrationData.loginCheck.loading"
            placeholder="Логин"
            @input="onLoginInput"
            @keydown.enter.prevent
        />
      </n-form-item>
      <n-form-item
          :show-feedback="false"
          :validation-status="passwordValidationStatus"
          label="Пароль"
          path="password"
      >
        <n-input
            v-model:value="registrationData.password"
            :allow-input="passwordAllowInput"
            :minlength="8"
            placeholder="Пароль"
            show-password-on="click"
            type="password"
            @blur="onSetPasswordHintsVisibility(false)"
            @focus="onSetPasswordHintsVisibility(true)"
            @input="passwordFieldTouched = true"
            @keydown.enter.prevent
        />
      </n-form-item>
      <n-form-item
          :show-feedback="false"
          :validation-status="passwordConfirmValidationStatus"
          label="Пароль ещё раз"
          path="passwordConfirm"
      >
        <n-input
            v-model:value="registrationData.passwordConfirm"
            :minlength="8"
            placeholder="Подтверждение пароля"
            show-password-on="click"
            type="password"
            @blur="onSetPasswordHintsVisibility(false)"
            @focus="onSetPasswordHintsVisibility(true)"
            @keydown.enter.prevent
        />
      </n-form-item>

      <n-collapse-transition :show="showPasswordHints" class="mb-10">
        <n-card bordered embedded size="small" style="--n-color-embedded: rgb(44, 44, 50)">
          <n-space vertical>
            <alt-password-err-item v-if="!passwordChecks[0]">
              Пароль должен содержать не меньше 8 символов
            </alt-password-err-item>

            <alt-password-err-item v-if="!passwordChecks[1]">
              Пароли не совпадают
            </alt-password-err-item>

            <alt-password-err-item v-if="!passwordChecks[2]">
              Рекомендуем добавить в пароль заглавные буквы, цифры и спецсимволы

              <template #icon>
                <n-icon color="#D1C12C" size="20">
                  <svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"
                       xmlns:xlink="http://www.w3.org/1999/xlink">
                    <path
                        d="M12 5.99L19.53 19H4.47L12 5.99M2.74 18c-.77 1.33.19 3 1.73 3h15.06c1.54 0 2.5-1.67 1.73-3L13.73 4.99c-.77-1.33-2.69-1.33-3.46 0L2.74 18zM11 11v2c0 .55.45 1 1 1s1-.45 1-1v-2c0-.55-.45-1-1-1s-1 .45-1 1zm0 5h2v2h-2z"
                        fill="currentColor"></path>
                  </svg>
                </n-icon>
              </template>
            </alt-password-err-item>

            <alt-password-err-item v-if="passwordChecks.every(el => el)">
              Всё в порядке, пароль подходит!

              <template #icon>
                <n-icon color="#28C638" size="20">
                  <svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"
                       xmlns:xlink="http://www.w3.org/1999/xlink">
                    <path
                        d="M12 2L4 5v6.09c0 5.05 3.41 9.76 8 10.91c4.59-1.15 8-5.86 8-10.91V5l-8-3zm6 9.09c0 4-2.55 7.7-6 8.83c-3.45-1.13-6-4.82-6-8.83V6.31l6-2.12l6 2.12v4.78zm-9.18-.5L7.4 12l3.54 3.54l5.66-5.66l-1.41-1.41l-4.24 4.24l-2.13-2.12z"
                        fill="currentColor"></path>
                  </svg>
                </n-icon>
              </template>
            </alt-password-err-item>
          </n-space>
        </n-card>
      </n-collapse-transition>
    </n-space>

    <n-button
        :disabled="!(passwordChecks[0] && passwordChecks[1]) || (!registrationData.loginCheck.available && !registrationData.loginCheck.loading) || registrationData.loginCheck.loading"
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
import {NButton, NCard, NCollapseTransition, NForm, NFormItem, NIcon, NInput, NSpace} from "naive-ui";
import type {FormItemInst} from "naive-ui";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";
import type {Ref} from "vue";
import {computed, ref} from "vue";
import AltPasswordErrItem from "@/module/authorization/views/registration-panels/AltPasswordErrItem.vue";
import type {altMP} from "@/connect/events/altMP";
import {debounce} from "@/data/debounce";

const emit = defineEmits<{
  (e: 'next-step'): void
}>()

const loginAllowInput = (value: string) => /^[0-9A-z\.\-_]*$/.test(value)
const passwordAllowInput = (value: string) => /^[0-9A-z\.\-_!@#$%^&*()]*$/.test(value)
const {
  registrationData,
  altMpAuth
}: { registrationData: Ref<RegistrationDTO>, altMpAuth: Ref<altMP> } = storeToRefs(useAuthStore())

const isPasswordFieldsFocused = ref(false)
const changeHuntsTimeout: Ref = ref(null)
const passwordFieldTouched = ref(false)

const loginInputRef = ref<FormItemInst | null>(null)

const onLoginInput = () => {
  registrationData.value.loginCheck.loading = true
  debounceCheckAvailable(registrationData.value.login)
}

const debounceCheckAvailable = debounce((value: string) => {
  altMpAuth.value.triggerServerWithAnswerPending("CheckUsername", value)
      .then(([result]) => {
        registrationData.value.loginCheck.available = result === false
        registrationData.value.loginCheck.error = false
      })
      .catch(() => {
        registrationData.value.loginCheck.available = false
        registrationData.value.loginCheck.error = true
      })
      .finally(() => {
        registrationData.value.loginCheck.loading = false
        loginInputRef.value?.validate({trigger: 'input'})
      })
}, 500)

const passwordChecks = computed(() => {
  const password = registrationData.value.password
  const passwordConfirm = registrationData.value.passwordConfirm
  return [
    password.length >= 8,
    password === passwordConfirm,
    /[A-Z]/.test(password) && /[0-9]/.test(password) && /[^A-z0-9]/.test(password)
  ]
})

const passwordValidationStatus = computed(() => {
  if (!passwordChecks.value[0] && passwordFieldTouched.value) return 'error'
  if (!passwordChecks.value[2] && passwordFieldTouched.value) return 'warning'
})

const passwordConfirmValidationStatus = computed(() => {
  if (!passwordChecks.value[1]) return 'error'
})

const showPasswordHints = computed(() => {
  return passwordFieldTouched.value && (isPasswordFieldsFocused.value || passwordChecks.value.some(el => !el))
})

const onSetPasswordHintsVisibility = (state: boolean) => {
  clearTimeout(changeHuntsTimeout.value)
  changeHuntsTimeout.value = setTimeout(() => {
    isPasswordFieldsFocused.value = state
  }, 100)
}

const onSubmit = () => {
  emit('next-step')
}
</script>

