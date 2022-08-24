<template>
  <div>
    <object :data="animatedLogo" type="image/svg+xml"></object>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import animatedLogo from "@/assets/logo.svg";


export default defineComponent({
  name: "LoaderView",
  data() {
    return {
      animatedLogo: animatedLogo
    }
  }
})
</script>

<style scoped>

</style>
