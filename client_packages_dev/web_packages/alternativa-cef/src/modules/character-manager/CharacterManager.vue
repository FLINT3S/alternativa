<template>
  <router-view v-slot="{Component}">
    <transition mode="out-in" name="fade">
      <component :is="Component"/>
    </transition>
  </router-view>
</template>

<script>
import AltOverlay from "@/components/core/AltOverlay";

export default {
  name: "CharacterManager",
  components: {AltOverlay},
  data() {
    return {
      moduleName: "CharacterManager",
    }
  }
}
</script>

<style scoped>

</style>
