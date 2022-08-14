<template>
  <main class="d-flex justify-content-center align-items-center" style="height: 100vh; background: var(--overlay-backdrop)">
    <div class="bg-black">
      <div>

        <h1>Авторизация</h1>
        <div class="d-flex">
          <input type="text" v-model="login" placeholder="Логин">
          <input type="password" v-model="password" placeholder="Пароль">
        </div>
        <div v-if="loginState !== null" :class="loginState ? 'text-success' : 'text-danger'">
          {{loginStateMessage}}
        </div>
        <button @click="submitLogin">Войти</button>
      </div>

      <h1>Регистрация</h1>
      <div class="d-flex">
        <input type="text" v-model="login" placeholder="Логин">
        <input type="password" v-model="password" placeholder="Пароль">
        <input type="email" v-model="email" placeholder="Электропочта">
      </div>
      <button @click="submitRegister">Регистрация</button>
    </div>
  </main>
</template>

<script>
import { defineComponent } from 'vue';
import {openOverlayMixin} from "@/mixins/openOverlayMixin";

export default defineComponent({
  name: 'AdminPanel',
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

<style lang="scss">

</style>
