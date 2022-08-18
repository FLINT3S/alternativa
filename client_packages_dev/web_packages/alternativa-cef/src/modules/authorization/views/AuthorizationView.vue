<template>
  <div class="home">
    <div class="bg-black">
      <div>

        <h1>Авторизация</h1>
        <div class="d-flex">
          <input v-model="login" placeholder="Логин" type="text">
          <input v-model="password" placeholder="Пароль" type="password">
        </div>
        <div v-if="loginState !== null" :class="loginState ? 'text-success' : 'text-danger'">
          {{ loginStateMessage }}
        </div>
        <button @click="submitLogin">Войти</button>
      </div>

      <h1>Регистрация</h1>
      <div class="d-flex">
        <input v-model="login" placeholder="Логин" type="text">
        <input v-model="password" placeholder="Пароль" type="password">
        <input v-model="email" placeholder="Электропочта" type="email">
      </div>
      <button @click="submitRegister">Регистрация</button>
    </div>
  </div>
</template>

<script>
import {defineComponent} from 'vue';

export default defineComponent({
  name: 'AuthorizationView',
  data() {
    return {
      login: "",
      password: "",
      email: "",
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
