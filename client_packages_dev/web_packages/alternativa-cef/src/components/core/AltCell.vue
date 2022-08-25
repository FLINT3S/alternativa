<template>
  <div class="alt-cell">
    <div class="alt-cell-inner">
      <div class="header">{{ header }}</div>
      <div class="caption">{{ caption }}</div>
    </div>
    <div class="alt-cell-right">
      <slot name="right">
        <span class="material-icons-round">
          chevron_right
        </span>
      </slot>
    </div>
  </div>
</template>

<script>
import {defineComponent} from 'vue';

export default defineComponent({
  name: 'AdminPanel',
  props: {
    header: {
      type: String,
      required: true
    },
    caption: {
      type: String,
      required: true
    }
  }
});
</script>

<style lang="scss" scoped>
.alt-cell {
  display: flex;
  align-items: center;

  .alt-cell-inner {
    .header {
      font-size: 16px;
      font-weight: 600;
    }

    .caption {
      font-size: 13px;
      font-weight: 400;
    }
  }
}
</style>
