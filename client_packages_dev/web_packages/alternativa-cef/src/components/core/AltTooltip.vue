<template>
  <div class="alt-tooltip">
    <div class="tooltip-icon d-flex">
      <slot name="icon">
        <span class="material-icons-round m-auto">help_outline</span>
      </slot>
    </div>
    <div class="tooltip-content">
      <slot></slot>
    </div>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltTooltip"
})
</script>

<style lang="scss" scoped>
.alt-tooltip {
  position: relative;
  right: 0;
  height: 100%;
  width: 40px;
  top: 0;
  display: flex;
  justify-content: center;
  align-content: center;

  .tooltip-icon {
    color: var(--text-secondary);
    z-index: 5;
  }

  .tooltip-icon:hover + .tooltip-content {
    opacity: 1;
  }

  .tooltip-content {
    // TODO: переменная
    background: rgba(0, 0, 0, .8);
    color: white;
    opacity: 0;
    transition: all .3s ease;
    padding: 4px;
    border-radius: 5px;
    font-size: 12px;
    text-align: center;
    position: absolute;
    bottom: 50px;
    min-width: 210px;
    max-width: 280px;
  }
}
</style>
