<template>
  <authorization-card>
    <h3>С возвращением!</h3>

    <div class="medium-text">
      Кажется, в последний раз ты играл с другого ПК<br>
      Просто войди в свой аккаунт!
    </div>

    <div class="mt-3">
      <alt-input
          v-model="login"
          placeholder="Логин"
          :input-state="loginState === false ? 'invalid' : loginState ? 'valid' : 'default'"
          stretched
      />
      <alt-input
          v-model="password"
          class="mt-2"
          placeholder="Пароль"
          :input-state="loginState === false ? 'invalid' : loginState ? 'valid' : 'default'"
          :caption="loginStateMessage"
          stretched
          type="password"
      />
      <p class="mt-2 small-text">
        Не помнишь пароль?
        <alt-link to="password-recovery">Восстановить</alt-link>
      </p>

      <alt-button
          class="mt-3"
          stretched
          @click="submitLogin"
          :variant="loginState ? 'success' : 'default'"
          :invalid-feedback="invalidLoginFeedback"
          @invalid-feedback-end="invalidLoginFeedback = false"
      >
        Войти в игру
      </alt-button>
    </div>
    <p class="mt-2 small-text">
      Нет аккаунта?
      <alt-link to="registration">Зарегистрироваться</alt-link>
    </p>
  </authorization-card>
</template>

<script>
import {defineComponent} from 'vue';
import AuthorizationCard from "@/modules/authorization/components/AuthorizationCard";
import AltButton from "@/components/core/AltButton";
import AltInput from "@/components/core/AltInput";
import AltLink from "@/components/core/AltLink";
import {altMpAuth} from "@/modules/authorization/data/altMpAuth";

export default defineComponent({
  name: 'LoginView',
  components: {AltInput, AltButton, AuthorizationCard, AltLink},
  data() {
    return {
      login: "",
      password: "",
      loginState: null,
      loginStateMessage: "",
      invalidLoginFeedback: false,
      loginAttempts: 0
    };
  },
  watch: {
    login() {
      this.loginState = null;
      this.loginStateMessage = "";
    },
    password() {
      this.loginState = null;
      this.loginStateMessage = "";
    }
  },
  methods: {
    submitLogin() {
      this.loginAttempts++

      if (this.loginAttempts > 10) {
        this.loginState = false;
        this.loginStateMessage = "Слишком много попыток!";
        return;
      }

      altMpAuth.triggerServer("LoginSubmit", this.login, this.password);
    },
    onLoginSuccess() {
      this.loginState = true
      this.loginStateMessage = ""
    },
    onLoginFailure(failureReason) {
      this.loginState = false
      this.invalidLoginFeedback = true

      switch (failureReason) {
        case "Wrong password":
          this.loginStateMessage = "Неверный пароль"
          break;
        case "Wrong login":
          this.loginStateMessage = "Нет аккаунта с таким логином"
          break;
      }
    }
  },
  created() {
    altMpAuth.on("LoginSuccess", this.onLoginSuccess)
    altMpAuth.onServer("LoginFailure", this.onLoginFailure)
  }
});
</script>
