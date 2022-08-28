<template>
  <div class="step" :class="{'active': isActive}" @click="$emit('click')">
    <span class="material-icons-round">{{ icon }}</span>
  </div>
  <div v-if="nextStepExists" class="next-line mx-2 w-100" :class="{'active': nextActive}"></div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "StepperStep",
  emits: ["click"],
  props: {
    name: {
      type: String,
      default: ""
    },
    isActive: {
      type: Boolean,
      default: undefined
    },
    nextActive: {
      type: Boolean,
      default: false
    },
    icon: {
      type: String,
      default: ""
    },
    nextStepExists: {
      type: Boolean,
      default: false
    },
  }
})
</script>

<style lang="scss" scoped>
.step {
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 32px;
  color: #fff;
  border-radius: 1000px;
  width: 56px;
  height: 56px;

  @media screen and (max-width: 1200px) {
    height: 48px;
    width: 48px;
    font-size: 26px;
  }
  transition: all .3s ease;
  aspect-ratio: 1;
  background-color: var(--text-secondary);
}

.next-line {
  height: 1px;
  margin-top: auto;
  margin-bottom: auto;
  background-color: var(--text-secondary);
  display: flex;
  max-width: 120px;
}

.active {
    background-color: var(--accent-primary);
}
</style>
