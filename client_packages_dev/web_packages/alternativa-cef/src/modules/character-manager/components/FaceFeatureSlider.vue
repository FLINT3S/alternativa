<template>
  <div class="text-center mb-3">
    <div>
      <slot></slot>
    </div>
    <alt-slider
        @input="v => $emit('update:modelValue', v)"
        :model-value="modelValue"
        :max="1"
        :marks="[-1, 1]"
        :min="-1"
        :process="false"
        :interval="0.1"
        :debounce="100"
        show-range
        show-value-tooltip
    />
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
