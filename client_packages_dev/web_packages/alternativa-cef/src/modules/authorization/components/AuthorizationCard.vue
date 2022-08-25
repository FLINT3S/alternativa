<template>
  <alt-card class="text-center" width="medium">
    <alt-logo height="150"/>
    <div class="mt-3">
      <slot/>
    </div>
  </alt-card>
</template>

<script>
import {defineComponent} from "vue";
import AltLogo from "@/components/logo/AltLogo";
import AltCard from "@/components/core/AltCard";

export default defineComponent({
  components: {AltLogo, AltCard},
})
</script>

<style scoped>

</style>
