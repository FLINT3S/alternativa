<template>
  <div class="text-center mb-3">
    <div>
      <slot></slot>
    </div>
    <alt-slider
        class="mt-1"
        @input="v => $emit('update:modelValue', v)"
        :model-value="modelValue"
        :max="1"
        :marks="[-1, 1]"
        :min="-1"
        :process="false"
        :interval="0.1"
        show-range
        show-value-tooltip
    />
    <hr class="mt-4">
  </div>
</template>

<script>
import AltSlider from "@/components/core/AltSlider";
export default {
  name: "FaceFeatureSlider",
  components: {AltSlider},
  props: {
    modelValue: {
      type: Number
    }
  }
}
</script>

<style scoped>

</style>
