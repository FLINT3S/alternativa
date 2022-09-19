<template>
  <n-card class="width-md text-center">
    <alt-logo/>

    <n-h2>С возвращением!</n-h2>

    <n-form
        :model="loginData"
        :rules="loginData.rules"
        size="large"
    >
      <n-space vertical>
        <n-form-item
            :show-feedback="false"
            :show-label="false"
            label="Введи логин"
            path="login"
        >
          <n-input
              v-model:value="loginData.login"
              placeholder="Логин"
              @keydown.enter.prevent
          />
        </n-form-item>
        <n-form-item
            :show-feedback="false"
            :show-label="false"
            label="Пароль"
            path="password"
        >
          <n-input
              v-model:value="loginData.password"
              placeholder="Пароль"
              type="password"
              @keydown.enter.prevent
          />
        </n-form-item>
      </n-space>

      <n-p depth="3">
        Не помнишь пароль?
        <router-link #="{ navigate, href }" custom to="password-recovery">
          <n-a :href="href" @click="navigate">Восстановить</n-a>
        </router-link>
      </n-p>

      <n-button
          :class="{'error-shake': submitError}"
          :disabled="submitDisabled"
          :type="submitError ? 'error' : 'primary'"
          block
          size="large"
          @click="submitLogin"
      >
        Войти
      </n-button>

      <n-p depth="3">
        Ещё нет аккаунта?
        <router-link #="{ navigate, href }" custom to="registration">
          <n-a :href="href" @click="navigate">Зарегистрировать</n-a>
        </router-link>
      </n-p>
    </n-form>
  </n-card>
</template>

<script lang="ts" setup>
import {NA, NButton, NCard, NForm, NFormItem, NH2, NInput, NP, NSpace} from 'naive-ui'
import AltLogo from "@/components/AltLogo.vue";
import {storeToRefs} from "pinia";
import {useAuthStore} from "@/store/auth";
import type {Ref} from "vue";
import {computed, ref} from "vue";
import type {LoginDTO} from "@/module/authorization/data/LoginDTO";
import type {altMP} from "@/connect/events/altMP";
import {useAltMpOffListeners} from "@/data/useAltMpOffListeners";


const {
  loginData,
  altMpAuth,
  authAttempts
}: {
  loginData: Ref<LoginDTO>,
  altMpAuth: Ref<altMP>,
  authAttempts: Ref<number>
} = storeToRefs(useAuthStore())

const submitError = ref(false)

const submitDisabled = computed(() => {
  return (!loginData.value?.validate?.isValid || authAttempts.value > 10)
})

const onLoginFailure = () => {
  submitError.value = true

  setTimeout(() => {
    submitError.value = false
  }, 3000)
}

useAltMpOffListeners(
    altMpAuth.value.onServer("LoginFailure", onLoginFailure),
)

const submitLogin = () => {
  authAttempts.value += 1
  altMpAuth.value.triggerServer("LoginSubmit", ...loginData.value.dto)
}
</script>

<style lang="scss">

</style>
