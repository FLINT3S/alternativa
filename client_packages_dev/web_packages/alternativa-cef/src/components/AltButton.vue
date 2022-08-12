<template>
  <button class="alt-button" :class="variant">
    <slot></slot>
  </button>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "alt-button",
  props: {
    variant: {
      type: String,
      default: "default",
      validator(value) {
        return ["default", "primary", "secondary"].includes(value);
      }
    }
  }
});
</script>

<style lang="scss" scoped>

</style>
