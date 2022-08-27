<template>
  <button :disabled="disabled" class="alt-button" :class="altButtonClass" ref="btnEl" v-if="to === null">
    <slot></slot>
  </button>
  <router-link :to="to" v-else custom v-slot="{navigate}">
    <button :disabled="disabled" class="alt-button" v-bind="$attrs" ref="btnEl" :class="altButtonClass" @click="navigate" @keypress.enter="navigate" role="button">
      <slot></slot>
    </button>
  </router-link>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "alt-button",
  props: {
    variant: {
      type: String,
      default: "default",
      validator(value) {
        return ["default", "primary", "secondary"].includes(value);
      }
    },
    size: {
      type: String,
      default: "l",
      validator(value) {
        return ["s", "m", "l", "xl"].includes(value);
      }
    },
    stretched: {
      type: Boolean,
      default: false
    },
    to: {
      type: String,
      default: null
    },
    disabled: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    altButtonClass() {
      const res = [this.variant + "-variant", "size-" + this.size]
      res.push(this.stretched ? "stretched" : "")

      return res.join(" ")
    }
  },
  methods: {
    focus() {
      this.$refs.btnEl.focus()
    }
  }
});
</script>

<style lang="scss" scoped>
.alt-button {
  padding: 14px 26px;
  font-size: 20px;
  border-radius: 5px;
  border: none;
  outline: none;
  background: var(--accent-primary);
  color: white;
  transition: all .3s ease;

  &:focus-visible {
    outline: 1px solid var(--accent-light)!important;
  }

  &:hover {
    box-shadow: 0 0 15px 2px rgba(255, 255, 255, 0.2);
  }

  &:active {
    transform: scale(0.99);
  }
}

.alt-button.stretched {
  width: 100%;
}

.alt-button:disabled {
  filter: grayscale(1);
}

.default-variant {

}
</style>
