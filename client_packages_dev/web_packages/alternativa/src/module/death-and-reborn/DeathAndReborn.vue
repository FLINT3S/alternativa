<template>
  <section class="death-and-reborn w-100">
    <div class="death-sing w-100 text-center">
      <transition appear name="fade">
        <n-element v-if="showDeathSign">
          <svg class="death-sign-bg" fill="var(--error-color-suppl)" height="auto" viewBox="0 0 1836 365" width="100%"
               xmlns="http://www.w3.org/2000/svg">
            <path d="M0 60.9319L1836 0V365L0 330.097V60.9319Z" fill="black" fill-opacity="0.35"/>
          </svg>
          <svg class="death-sign-text" fill="var(--error-color-suppl)" height="auto" viewBox="0 0 615 114" width="35%"
               xmlns="http://www.w3.org/2000/svg">
            <path
                d="M0.869805 0.809995H63.7698V92.27H98.7898V113.69H49.8298C46.6565 113.69 43.5965 112.727 40.6498 110.8C37.3631 108.533 35.7198 105.927 35.7198 102.98V22.4H28.9198V87H0.869805V0.809995ZM105.778 22.4H98.9784V65.58H105.778V22.4ZM133.828 76.29C133.828 83.43 129.182 87 119.888 87H84.8684C75.5751 87 70.9284 83.43 70.9284 76.29V11.69C70.9284 4.43666 75.5751 0.809995 84.8684 0.809995H119.888C129.182 0.809995 133.828 4.43666 133.828 11.69V76.29ZM208.477 76.29C208.477 83.43 203.83 87 194.537 87H159.517C150.224 87 145.577 83.43 145.577 76.29V27.67H138.607V6.25H145.577V0.809995H173.627V6.25H208.477V27.67H173.627V65.58H180.597V33.11H208.477V76.29ZM250.544 22.4H243.744V33.11H250.544V22.4ZM278.594 43.82C278.594 51.0733 273.947 54.7 264.654 54.7H243.744V87H215.694V0.809995H264.654C273.947 0.809995 278.594 4.43666 278.594 11.69V43.82ZM320.603 22.4H313.803V33.11H320.603V22.4ZM334.713 113.69C331.539 113.69 328.479 112.727 325.533 110.8C322.246 108.533 320.603 105.927 320.603 102.98V54.7H313.803V87H285.753V11.69C285.753 4.43666 290.399 0.809995 299.693 0.809995H334.713C344.006 0.809995 348.653 4.43666 348.653 11.69V92.27H383.673V113.69H334.713ZM390.661 54.53H369.751C360.458 54.53 355.811 50.96 355.811 43.82V0.809995H383.861V33.11H390.661V0.809995H418.711L390.661 54.53ZM390.661 0.809995H418.711V92.27H453.731V113.69H404.771C401.598 113.69 398.538 112.727 395.591 110.8C392.305 108.533 390.661 105.927 390.661 102.98V54.53V0.809995ZM453.92 33.11H473.47V54.7H453.92V65.58H473.47V87H425.87V0.809995H473.47V22.4H453.92V33.11ZM530.113 113.69C526.94 113.69 523.88 112.727 520.933 110.8C517.646 108.533 516.003 105.927 516.003 102.98V54.7H509.203V87H481.153V0.809995H509.203V33.11H516.003V0.809995H544.053V92.27H579.073V113.69H530.113ZM586.062 22.4H579.262V65.58H586.062V22.4ZM614.112 76.29C614.112 83.43 609.465 87 600.172 87H565.152C555.858 87 551.212 83.43 551.212 76.29V11.69C551.212 4.43666 555.858 0.809995 565.152 0.809995H600.172C609.465 0.809995 614.112 4.43666 614.112 11.69V76.29Z"
                fill="var(--error-color)"/>
          </svg>
          <n-h3 style="z-index: 1; position: relative; margin-top: 0; margin-bottom: 0;">{{ deathReason }}</n-h3>
          <n-h2 style="z-index: 1; position: relative; margin-top: 12px; margin-bottom: 0;">
            До возрождения - {{ time }}
          </n-h2>
        </n-element>
      </transition>

    </div>
  </section>
</template>

<script lang="ts" setup>
import {NElement, NH2, NH3} from 'naive-ui'
import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";
import {useDeathAndRebornStore} from "@/store/deathAndReborn";
import {computed} from "vue";

const {overlayBackdropTransition} = storeToRefs(useRootStore())
overlayBackdropTransition.value = false

const {showDeathSign, secondsToReborn, deathReason} = storeToRefs(useDeathAndRebornStore())

const time = computed(() => {
  const seconds = secondsToReborn.value
  const minutes = Math.floor(seconds / 60)
  const secondsLeft = seconds % 60

  return `${minutes.toString().padStart(2, '0')}:${secondsLeft.toString().padStart(2, '0')}`
})
</script>

<style scoped>
.death-sign-bg {
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
}

.death-sign-text {
  position: relative;
  z-index: 0;
}
</style>
