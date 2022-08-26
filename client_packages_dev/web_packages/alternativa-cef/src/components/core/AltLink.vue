<template>
  <div class="position-relative d-inline-block alt-link">
    <router-link :to="to" class="alt-link__inner" v-bind="$attrs">
      <slot></slot>
    </router-link>
    <span class="underline"></span>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltLine",
  props: {
    to: {
      type: String,
      required: true
    }
  }
})
</script>

<style scoped lang="scss">
.alt-link, .alt-link a {
  color: var(--accent-primary);
  text-decoration: none;

  .underline {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 0;
    height: 1px;
    transition: all .3s ease;
    background-color: var(--accent-primary);
  }

  &:hover, .alt-link__inner:focus-visible + {
    .underline {
      width: 100%;
    }
  }

  .alt-link__inner:focus-visible {
    outline: 1px solid rgba(25, 138, 234, .5);
    border-radius: 3px;
  }
}
</style>
