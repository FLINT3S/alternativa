<template>
  <div class="alt-pill" :class="{'disabled': disabled}">
    <slot></slot>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltPill",
  props: {
    disabled: {
      type: Boolean,
      default: false
    }
  },
})
</script>

<style scoped lang="scss">
.alt-pill {
  border-radius: 100px;
  background-color: var(--accent-primary);
  color: white;
  font-size: 16px;
  padding: 5px 10px;
}

.disabled {
  background-color: var(--text-secondary);
}
</style>
