<template>
  <section class="death-and-reborn w-100">
    <div class="death-sing w-100 text-center">
      <transition appear name="fade">
        <n-element v-if="showDeathSign">
          <svg class="death-sign-bg" fill="var(--error-color-suppl)" height="auto" viewBox="0 0 1836 365" width="100%"
               xmlns="http://www.w3.org/2000/svg">
            <path d="M0 60.9319L1836 0V365L0 330.097V60.9319Z" fill="black" fill-opacity="0.35"/>
          </svg>
          <svg class="death-sign-text" fill="var(--error-color-suppl)" height="auto" viewBox="0 0 1836 265" width="100%"
               xmlns="http://www.w3.org/2000/svg">
            <path
                d="M610.57 135.81H673.47V227.27H708.49V248.69H659.53C656.357 248.69 653.297 247.727 650.35 245.8C647.063 243.533 645.42 240.927 645.42 237.98V157.4H638.62V222H610.57V135.81ZM715.479 157.4H708.679V200.58H715.479V157.4ZM743.529 211.29C743.529 218.43 738.882 222 729.589 222H694.569C685.275 222 680.629 218.43 680.629 211.29V146.69C680.629 139.437 685.275 135.81 694.569 135.81H729.589C738.882 135.81 743.529 139.437 743.529 146.69V211.29ZM818.177 211.29C818.177 218.43 813.531 222 804.237 222H769.217C759.924 222 755.277 218.43 755.277 211.29V162.67H748.307V141.25H755.277V135.81H783.327V141.25H818.177V162.67H783.327V200.58H790.297V168.11H818.177V211.29ZM860.244 157.4H853.444V168.11H860.244V157.4ZM888.294 178.82C888.294 186.073 883.648 189.7 874.354 189.7H853.444V222H825.394V135.81H874.354C883.648 135.81 888.294 139.437 888.294 146.69V178.82ZM930.303 157.4H923.503V168.11H930.303V157.4ZM944.413 248.69C941.239 248.69 938.179 247.727 935.233 245.8C931.946 243.533 930.303 240.927 930.303 237.98V189.7H923.503V222H895.453V146.69C895.453 139.437 900.099 135.81 909.393 135.81H944.413C953.706 135.81 958.353 139.437 958.353 146.69V227.27H993.373V248.69H944.413ZM1000.36 189.53H979.451C970.158 189.53 965.511 185.96 965.511 178.82V135.81H993.561V168.11H1000.36V135.81H1028.41L1000.36 189.53ZM1000.36 135.81H1028.41V227.27H1063.43V248.69H1014.47C1011.3 248.69 1008.24 247.727 1005.29 245.8C1002 243.533 1000.36 240.927 1000.36 237.98V189.53V135.81ZM1063.62 168.11H1083.17V189.7H1063.62V200.58H1083.17V222H1035.57V135.81H1083.17V157.4H1063.62V168.11ZM1139.81 248.69C1136.64 248.69 1133.58 247.727 1130.63 245.8C1127.35 243.533 1125.7 240.927 1125.7 237.98V189.7H1118.9V222H1090.85V135.81H1118.9V168.11H1125.7V135.81H1153.75V227.27H1188.77V248.69H1139.81ZM1195.76 157.4H1188.96V200.58H1195.76V157.4ZM1223.81 211.29C1223.81 218.43 1219.17 222 1209.87 222H1174.85C1165.56 222 1160.91 218.43 1160.91 211.29V146.69C1160.91 139.437 1165.56 135.81 1174.85 135.81H1209.87C1219.17 135.81 1223.81 139.437 1223.81 146.69V211.29Z"
                fill="var(--error-color)"/>
          </svg>
          <n-h2 style="z-index: 1; position: relative;">
            До возрождения - {{ time }}
          </n-h2>
        </n-element>
      </transition>

    </div>
  </section>
</template>

<script lang="ts" setup>
import {NElement, NH2} from 'naive-ui'
import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";
import {useDeathAndRebornStore} from "@/store/deathAndReborn";
import {computed} from "vue";

const {overlayBackdropTransition} = storeToRefs(useRootStore())
overlayBackdropTransition.value = false

const {showDeathSign, secondsToReborn} = storeToRefs(useDeathAndRebornStore())

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
  height: 100%;
}

.death-sign-text {
  position: relative;
  z-index: 0;
}
</style>
