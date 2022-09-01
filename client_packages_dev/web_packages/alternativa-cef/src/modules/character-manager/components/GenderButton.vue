<template>
  <div :class="active && 'active'"
       class="gender"
       @click="$emit('click')">
    <div class="icon">
      <span class="material-icons-round">
        {{icon}}
      </span>
    </div>
    <div class="caption small-text text-secondary">
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "GenderButton",
  emits: ["click"],
  props: {
    active: {
      type: Boolean,
      default: false
    },
    icon: {
      type: String,
      required: true
    }
  }
}
</script>

<style lang="scss" scoped>
.gender {
  .icon {
    padding: 14px;
    border-radius: 1000px;
    background-color: var(--text-secondary);
    display: flex;
    aspect-ratio: 1;
    margin: 0 8px;

    span {
      margin: auto;
      font-size: 40px;
    }
  }

  .caption {
    margin-top: 4px;
  }

  &.active {
    .icon {
      background-color: var(--accent-primary);
    }
  }
}
</style>
