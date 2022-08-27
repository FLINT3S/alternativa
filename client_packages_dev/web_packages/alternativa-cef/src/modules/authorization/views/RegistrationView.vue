<template>
  <authorization-card>
    <h3>Регистрация</h3>

    <div class="medium-text">
      Логин будет использоваться для входа в аккаунт и на игровой форум.
      Логин может содержать латинские буквы, цифры и знаки нижнего подчеркивания, точку и короткое тире
    </div>

    <div class="mt-3">
      <alt-input
          v-model="registrationData.login"
          placeholder="Логин"
          stretched
          :validation="v$.registrationData.login"
          show-validation-tooltip

      />

      <alt-button :disabled="v$.registrationData.login.$invalid" class="mt-3" stretched @click="submitLogin">Дальше</alt-button>
    </div>
    <p class="mt-2 small-text">
      Уже есть аккаунт?
      <alt-link to="/login">Войти</alt-link>
    </p>
  </authorization-card>
</template>

<script>
import {defineComponent} from 'vue';
import AuthorizationCard from "@/modules/authorization/components/AuthorizationCard";
import AltButton from "@/components/core/AltButton";
import AltInput from "@/components/core/AltInput";
import AltLink from "@/components/core/AltLink";
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";
import useVuelidate from "@vuelidate/core";

export default defineComponent({
  name: 'RegistrationView',
  components: {AltInput, AltButton, AuthorizationCard, AltLink},
  setup() {
    return {v$: useVuelidate()}
  },
  data() {
    return {
      registrationData: new RegistrationDTO()
    };
  },
  validations() {
    return {
      registrationData: {
        ...RegistrationDTO.validators
      }
    }
  },
  methods: {
    submitLogin() {
      this.$altMp.triggerServer("LoginSubmit", this.login, this.password);
    },
    submitRegister() {
      this.$altMp.triggerServer("RegisterSubmit", this.login, this.password, this.email);
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
