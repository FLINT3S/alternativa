<template>
  <authorization-card>
    <h3>С возвращением!</h3>

    <div class="medium-text">
      Кажется, в последний раз ты играл с другого ПК<br>
      Просто войди в свой аккаунт!
    </div>

    <form class="mt-3">
      <alt-input
          v-model="login"
          stretched
          placeholder="Логин"
      />
      <alt-input
          v-model="password"
          stretched
          placeholder="Пароль"
          type="password"
          class="mt-2"
      />
      <p class="mt-2 small-text">
        Забыли пароль? <alt-link to="/password-recovery">Восстановить</alt-link>
      </p>

      <alt-button class="mt-3" stretched @click="submitLogin">Войти в игру</alt-button>
    </form>
    <p class="mt-2 small-text">
      Нет аккаунта? <alt-link to="/registration">Зарегистрироваться</alt-link>
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
  name: 'AuthorizationView',
  components: {AltInput, AltButton, AuthorizationCard, AltLink},
  data() {
    return {
      login: "",
      password: "",
      loginState: null,
      loginStateMessage: ""
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
