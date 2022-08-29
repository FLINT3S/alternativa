<template>
  <authorization-card>
    <h3>Регистрация</h3>

    <div class="d-flex justify-content-center mb-3">
      <stepper-step
          v-for="(step, index) in registrationSteps"
          :key="step.name"
          @click="setStep(index)"
          :icon="step.icon"
          :isActive="activeStep >= index"
          :nextActive="activeStep > index"
          :name="step.name"
          :next-step-exists="index < registrationSteps.length - 1"
      />
    </div>

    <transition name="fade" mode="out-in" :duration="200">
      <component
          class="transition-default"
          :is="getRegistrationComponent"
          :registration-state="registrationState"
          @submit="onRegisterSubmit"
          @next-step="nextStep"
      />
    </transition>

    <p class="mt-2 small-text">
      Уже есть аккаунт?
      <alt-link to="login">Войти</alt-link>
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
import {altMpAuth} from "@/modules/authorization/data/altMpAuth";

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
      activeStep: 0,
      registrationState: false
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
    getRegistrationComponent() {
      switch (this.activeStep) {
        case 0:
          return "common-information";
        case 1:
          return "additional-information";
        case 2:
          return "policy-confirm";
        default:
          return "common-information";
      }
    }
  },
  methods: {
    nextStep() {
      this.activeStep++;
    },
    onRegisterSubmit() {
      altMpAuth.triggerServer("RegisterSubmit", this.registrationData.login, this.registrationData.password, this.registrationData.email);
    },
    setStep(index) {
      if (index < this.activeStep) {
        this.activeStep = index;
      }
    },
    onRegisterSuccess() {
      this.registrationState = true;
    }
  },
  mounted() {
    altMpAuth.on("RegisterSuccess", this.onRegisterSuccess);
  }
});
</script>

<style lang="scss" scoped>

</style>
