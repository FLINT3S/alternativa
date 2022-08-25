<template>
  <router-link :to="to" class="alt-link" v-bind="$attrs">
    <slot></slot>
  </router-link>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltLine",
  props: {
    to: {
      type: String,
      required: true
    }
  }
})
</script>

<style scoped>
.alt-link {
  color: var(--accent-primary);
  text-decoration: none;
}
</style>
