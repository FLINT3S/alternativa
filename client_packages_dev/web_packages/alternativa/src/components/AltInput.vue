<template>
  <n-element class="alt-input w-100" tag="div">
    <n-input v-bind="$attrs" :on-input="onInput"></n-input>
    <div class="feedback" :class="{'show': showFeedback}">
      <slot name="feedback"></slot>
    </div>
  </n-element>
</template>

<script lang="ts" setup>
import {NElement, NInput} from 'naive-ui'
import {computed, useAttrs} from "vue";

const attrs: any = useAttrs()

const showFeedback = computed(() => {
  return attrs.showFeedback || attrs['show-feedback'] || (attrs?.validate?.touched && !attrs?.validate?.isValid)
})

const onInput = (value: string) => {
  if (attrs?.validate?.touched !== undefined) {
    attrs.validate.touched = true
  }
}
</script>

<style scoped lang="scss">
.feedback {
  height: 0;
  opacity: 0;
  transition: height 0.3s ease, opacity 0.3s ease;

  &.show {
    height: 24px;
    opacity: 1;
  }
}
</style>
