<template>
  <router-view v-slot="{Component}">
    <transition mode="out-in" name="fade">
      <component :is="Component"/>
    </transition>
  </router-view>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AdminPanel"
})
</script>

<style scoped>

</style>
