<template>
  <div class="stepper">
    <div class="steps-line d-flex">
      <stepper-step
          v-for="(step, index) in steps"
          :key="step.uid"
          :name="step.name"
          :is-active="activeStepNumber === index"
          :next-step-exists="index < steps.length - 1"
          :icon="step.icon"
      />
    </div>
  </div>
</template>

<script>
import StepperStep from "@/components/core/stepper/Step";

export default {
  name: "AltStepper",
  components: {StepperStep},
  props: {
    steps: {
      type: Array,
      default: () => []
    },
    activeStepNumber: {
      type: Number,
      default: 0
    }
  }
}
</script>

<style scoped>

</style>
