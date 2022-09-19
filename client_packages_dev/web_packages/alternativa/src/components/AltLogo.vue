<template>
  <div class="alt-logo">
    <object :data="shimmerLogo" type="image/svg+xml" :height="adaptiveHeight"/>
  </div>
</template>

<script lang="ts">
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
      shimmerLogo: shimmerLogo,
      adaptiveHeight: 120
    }
  },
  mounted() {
    if (window.innerWidth < 1200) {
      this.adaptiveHeight = this.height / 1.5
    } else {
      this.adaptiveHeight = this.height
    }
  }
})
</script>

<style scoped>

</style>
