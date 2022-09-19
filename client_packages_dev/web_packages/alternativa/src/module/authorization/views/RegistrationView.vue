<template>
  <n-card class="width-xl text-center">
    <alt-logo/>

    <n-h2
        style="margin-bottom: 6px;"
    >
      Добро пожаловать!
    </n-h2>


    <n-divider
        dashed
        style="margin-top: 14px;"
    >
      <n-p
          depth="3"
          style="margin-top: 0;"
      >
        Пройди небольшую регистрацию и врывайся в игру
      </n-p>
    </n-divider>

    <div class="d-flex">
      <n-steps
          v-model:current="currentStep"
          style="width: auto"
          vertical
      >
        <n-step
            :disabled="currentStep < 2"
            title="Основные данные"
        />
        <n-step
            :disabled="currentStep < 3"
            title="Почта"
        />
        <n-step
            :disabled="currentStep < 4"
            title="Промокод"
        />
        <n-step
            :disabled="currentStep < 4"
            title="Завершение"
        />
      </n-steps>

      <n-divider
          dashed
          style="height: auto; margin-left: 12px; margin-right: 24px;"
          vertical
      />

      <div class="content w-100">
        <transition mode="out-in" name="fade">
          <component :is="activePanel" @next-step="onNextStep"></component>
        </transition>
      </div>
    </div>

    <n-divider dashed/>

    <n-p depth="3">
      Уже есть аккаунт?
      <router-link #="{ navigate, href }" custom to="login">
        <n-a :href="href" @click="navigate">Войти</n-a>
      </router-link>
    </n-p>
  </n-card>
</template>

<script lang="ts" setup>
import {NA, NCard, NDivider, NH2, NP, NStep, NSteps} from 'naive-ui'
import AltLogo from "@/components/AltLogo.vue";
import {computed, ref} from "vue";
import CommonInfo from "@/module/authorization/views/registration-panels/CommonInfo.vue";
import EmailInfo from "@/module/authorization/views/registration-panels/EmailInfo.vue";
import PromoInfo from "@/module/authorization/views/registration-panels/PromoInfo.vue";
import RegistrationEnd from "@/module/authorization/views/registration-panels/RegistrationEnd.vue";
import {useAuthStore} from "@/store/auth";
import {storeToRefs} from "pinia";

const currentStep = ref(1)
const {altMpAuth, registrationData} = storeToRefs(useAuthStore())

const activePanel = computed(() => {
  switch (currentStep.value) {
    case 1:
      return CommonInfo
    case 2:
      return EmailInfo
    case 3:
      return PromoInfo
    case 4:
      return RegistrationEnd
  }
})

const onNextStep = () => {
  if (currentStep.value < 4) {
    currentStep.value++
  } else if (currentStep.value === 4) {
    altMpAuth.value.triggerServer("RegisterSubmit", ...registrationData.value.dto);
  }
}
</script>

<style scoped>

</style>
