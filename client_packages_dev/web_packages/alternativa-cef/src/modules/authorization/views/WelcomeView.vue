<template>
  <authorization-card>
    <h3>Привет!</h3>
    <div class="mt-2">
      Добро пожаловать на Alternativa Role Play!
      <br>
      <span class="medium-text">
        Мы рады видеть тебя в рядах наших игроков,<br>
        и сделаем всё, чтобы ты получил<br>
        лучший игровой опыт!
      </span>
    </div>

    <alt-button ref="startBtnRef" class="mt-3" stretched to="/registration">
      Начать играть
    </alt-button>

    <div class="help-caption mt-2">Если не отображается курсор — нажми Ё(~). Это работает в&nbsp;любом&nbsp;интерфейсе&nbsp;сервера</div>
  </authorization-card>
</template>

<script>
import {defineComponent} from "vue";
import AltButton from "@/components/core/AltButton";
import AuthorizationCard from "@/modules/authorization/components/AuthorizationCard";

export default defineComponent({
  name: "WelcomeView",
  components: {AuthorizationCard, AltButton},
  mounted() {
    this.$nextTick(() => {
      this.$refs.startBtnRef.focus();
    })
  }
})
</script>

<style lang="scss" scoped>
.help-caption {
  opacity: .6;
  font-size: 13px;
}
</style>
