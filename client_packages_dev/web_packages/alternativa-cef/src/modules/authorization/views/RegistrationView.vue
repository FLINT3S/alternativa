<template>
  <authorization-card>
    <h3>Регистрация</h3>

    <div class="medium-text">
      Логин будет использоваться для входа в аккаунт и на игровой форум.
      Логин может содержать латинские буквы, цифры и знаки нижнего подчеркивания, точку и короткое тире
    </div>

    <div class="mt-3">
      <alt-input
          v-model="login"
          placeholder="Логин"
          stretched
      />
      <alt-input
          v-model="password"
          class="mt-2"
          placeholder="Пароль"
          stretched
          type="password"
      />
      <p class="mt-2 small-text">
        Не помнишь пароль?
        <alt-link to="/password-recovery">Восстановить</alt-link>
      </p>

      <alt-button class="mt-3" stretched @click="submitLogin">Войти в игру</alt-button>
    </div>
    <p class="mt-2 small-text">
      Нет аккаунта?
      <alt-link to="/registration">Зарегистрироваться</alt-link>
    </p>
  </authorization-card>
</template>

<script>
import {defineComponent} from 'vue';
import AuthorizationCard from "@/modules/authorization/components/AuthorizationCard";
import AltButton from "@/components/core/AltButton";
import AltInput from "@/components/core/AltInput";
import AltLink from "@/components/core/AltLink";

export default defineComponent({
  name: 'RegistrationView',
  components: {AltInput, AltButton, AuthorizationCard, AltLink},
  data() {
    return {
      registrationData: new RegistrationDTO()
    };
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
