<template>
  <div class="text-center">
    <object :data="animatedLogo" type="image/svg+xml"></object>
    <div :style="longLoadingHint ? {opacity: 1, height: '100px'} : {opacity: 0, height: 0}" class="loading-timeout transition-default mx-auto">
      Игра слишком долго грузится, возможно, что-то пошло не так...<br>
      Если игра не загрузится в ближайшие несколько секунд - попробуй перезайти
    </div>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import animatedLogo from "@/assets/logo/animatedLoadingAlternativaLogo.svg";


export default defineComponent({
  name: "LoaderView",
  data() {
    return {
      animatedLogo: animatedLogo,
      longLoadingHint: false,
      longLoadingTimeout: null
    }
  },
  mounted() {
    this.longLoadingTimeout = setTimeout(() => {
      this.longLoadingHint = true;
    }, 12000)
  },
  deactivated() {
    clearTimeout(this.longLoadingTimeout)
  }
})
</script>
