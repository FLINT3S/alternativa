<template>
  <authorization-card>
    <h3>Регистрация</h3>

    <div class="d-flex justify-content-center mb-3">
      <stepper-step
          v-for="(step, index) in registrationSteps"
          :key="step.name"
          :icon="step.icon"
          :isActive="activeStep >= index"
          :nextActive="activeStep > index"
          :name="step.name"
          :next-step-exists="index < registrationSteps.length - 1"
      />
    </div>

    <transition-group name="collapse-right" tag="div" class="position-relative d-flex flex-row-reverse justify-content-center">
      <common-information
          v-if="activeStep === 0"
          key="common-information"
          class="w-100"
          @next-step="nextStep"
      />
      <additional-information
          v-if="activeStep === 1"
          key="additional-information"
          class="w-100"
          @next-step="nextStep"
      />
      <policy-confirm
          v-if="activeStep === 2"
          key="policy-confirm"
          class="w-100"
          @submit="onRegisterSubmit"
      ></policy-confirm>
    </transition-group>

    <p class="mt-2 small-text">
      Уже есть аккаунт?
      <alt-link to="/login">Войти</alt-link>
    </p>
  </authorization-card>
</template>

<script>
import {defineComponent} from 'vue';
import AuthorizationCard from "@/modules/authorization/components/AuthorizationCard";
import AltLink from "@/components/core/AltLink";
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";
import useVuelidate from "@vuelidate/core";
import StepperStep from "@/components/core/stepper/Step";
import {mapGetters} from "vuex";
import CommonInformation from "@/modules/authorization/components/registration/CommonInformation";
import AdditionalInformation from "@/modules/authorization/components/registration/AdditionalInformation";
import PolicyConfirm from "@/modules/authorization/components/registration/PolicyConfirm";

export default defineComponent({
  name: 'RegistrationView',
  components: {PolicyConfirm, AdditionalInformation, CommonInformation, StepperStep, AuthorizationCard, AltLink},
  setup() {
    return {v$: useVuelidate()}
  },
  data() {
    return {
      registrationSteps: [
        {
          name: "Пароль",
          icon: "vpn_key",
        },
        {
          name: "Логин",
          icon: "badge",
        },
        {
          name: "Правила",
          icon: "policy",
        }
      ],
      activeStep: 0
    };
  },
  validations() {
    return {
      registrationData: {
        ...RegistrationDTO.validators
      }
    }
  },
  computed: {
    ...mapGetters([
      "registrationData"
    ]),
  },
  methods: {
    nextStep() {
      this.activeStep++;
    },
    onRegisterSubmit() {
      this.$altMp.triggerServer("RegisterSubmit", this.registrationData.login, this.registrationData.password, this.registrationData.email);
    }
  },
  created() {
    this.$altMp.onServer("LoginSuccess", () => {
      this.loginState = true
      this.loginStateMessage = "Успешный логин"
    })
    this.$altMp.onServer("LoginFailure", (failureReason) => {
      this.loginState = false
      this.loginStateMessage = failureReason
    })
  }
});
</script>

<style lang="scss" scoped>

</style>
