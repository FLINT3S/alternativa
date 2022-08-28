<template>
  <div class="common-info">
    <h4>Основная информация</h4>

    <div class="mt-3">
      <alt-input
          v-model="registrationData.login"
          :validation="v$.registrationData.login"
          class="w-100"
          placeholder="Логин"
          show-validation-tooltip
          :debounce="500"
          :pattern="/^[0-9A-z\.\-_]*$/"
          :input-state="loginInputState"
          :caption="loginInputCaption"
          show-caption-on-focus
          stretched
      />
    </div>

    <div class="mt-2">
      <alt-input
          v-model="registrationData.password"
          :validation="v$.registrationData.password"
          placeholder="Пароль"
          stretched
          type="password"
      ></alt-input>
      <alt-input
          v-model="passwordConfirmation"
          class="mt-2"
          :input-state="passwordConfirmationState"
          placeholder="Ещё раз пароль"
          stretched
          show-error-on-focus
          show-valid-on-focus
          type="password"
      ></alt-input>

      <div class="mt-2 password-checkers">
        <div v-for="check in passwordChecks" :key="check.text" class="d-flex">
          <span :class="check.status" class="material-icons-round check-icon my-auto me-1">{{ check.icon }}</span>
          <span class="password-check-text small-text my-auto">{{ check.text }}</span>
        </div>
      </div>
    </div>

    <alt-button :disabled="v$.registrationData.login.$invalid || !passwordValid" class="mt-3" stretched
                @click="nextStep">
      Дальше
    </alt-button>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import AltButton from "@/components/core/AltButton";
import AltInput from "@/components/core/AltInput";
import {mapGetters} from "vuex";
import useVuelidate from "@vuelidate/core";
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";

export default defineComponent({
  name: "CommonInformation",
  components: {AltInput, AltButton},
  data() {
    return {
      passwordConfirmation: "",
      isLoginTaken: false,
    }
  },
  setup() {
    return {v$: useVuelidate()}
  },
  computed: {
    ...mapGetters([
      "registrationData"
    ]),
    passwordChecks() {
      const res = []

      if (!this.registrationData.password || this.registrationData.password?.length < 8) {
        res.push({
          icon: "priority_high",
          status: "err",
          text: "Не менее 8 символов"
        })
      } else {
        res.push({
          icon: "check",
          status: "ok",
          text: "Не менее 8 символов"
        })
      }

      if (this.passwordConfirmation === this.registrationData.password) {
        res.push({
          icon: "check",
          status: "ok",
          text: "Пароли совпадают"
        })
      } else {
        res.push({
          icon: "priority_high",
          status: "err",
          text: "Пароли не совпадают"
        })
      }

      return res
    },
    passwordValid() {
      return this.passwordChecks.map(check => check.status !== "err").every(Boolean)
    },
    passwordConfirmationState() {
      if (!this.registrationData.password) return 'default'
      return this.passwordConfirmation === this.registrationData.password ? 'valid' : 'invalid'
    },
    loginInputState() {
      if (this.v$.registrationData.login.$invalid || !this.registrationData.login) return 'default'
      return this.isLoginTaken ? 'invalid' : 'valid'
    },
    loginInputCaption() {
      if (this.v$.registrationData.login.$invalid || !this.registrationData.login) return ""
      return this.isLoginTaken ? "Логин занят" : "Логин свободен"
    }
  },
  validations() {
    return {
      registrationData: {
        ...RegistrationDTO.validators
      }
    }
  },
  methods: {
    nextStep() {
      this.$emit("nextStep");
    }
  }
})
</script>

<style lang="scss" scoped>
.password-checkers {
  background-color: var(--color-background-secondary);
  padding: 8px;
  border-radius: 5px;
}

.check-icon {
  &.ok {
    color: var(--success);
  }

  &.err {
    color: var(--danger);
  }

  &.warn {
    color: var(--warning);
  }
}
</style>
