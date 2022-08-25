<template>
  <div class="alt-logo">
    <object :data="shimmerLogo" type="image/svg+xml" :height="height"/>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import shimmerLogo from "@/assets/logo/animatedShimmerAlternativaLogo.svg";

export default defineComponent({
  name: "AltLogo",
  props: {
    height: {
      default: 120
    }
  },
  data() {
    return {
      shimmerLogo: shimmerLogo
    }
  }
})
</script>

<style scoped>

</style>
