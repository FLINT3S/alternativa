<template>
  <main class="d-flex justify-content-center align-items-center" style="height: 100vh; background: var(--overlay-backdrop)">
    <div class="bg-black">
      <h1>Авторизация</h1>
      <div class="d-flex">
        <input type="text" v-model="login" placeholder="Логин">
        <input type="password" v-model="password" placeholder="Пароль">
      </div>
      <button @click="submitLogin">Войти</button>

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
      email: ""
    };
  },
  methods: {
    submitLogin() {
      this.$altMp.triggerServer("CEF:SERVER:Authorization:Login", {
        login: this.login,
        password: this.password
      });
    },
    submitRegister() {
      this.$altMp.triggerServer("CEF:SERVER:Authorization:Register", {
        login: this.login,
        password: this.password,
        email: this.email
      });
    }
  }
});
</script>

<style lang="scss">

</style>
