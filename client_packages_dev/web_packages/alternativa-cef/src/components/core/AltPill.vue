<template>
  <div class="alt-pill" :class="{'disabled': disabled, [size]: true}">
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
    },
    size: {
      type: String,
      default: "medium"
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
  transition: background-color .3s ease;

  &.small {
    font-size: 14px;
    padding: 4px 6px;
  }
}

.disabled {
  background-color: var(--text-secondary);
}
</style>
