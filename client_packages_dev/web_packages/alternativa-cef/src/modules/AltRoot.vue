<template>
  <router-view v-slot="{Component}">
    <transition mode="out-in" name="fade">
      <component :is="Component"/>
    </transition>
  </router-view>
</template>

<script>
import {altMP} from "@/connect/events/altMP";
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltRoot",
  data() {
    return {
      altMpRoot: new altMP("Root", "1")
    }
  },
  mounted() {
    this.altMpRoot.on("GoTo", (location) => {
      this.$router.push(location);
    });
  }
})
</script>

<style scoped>

</style>
