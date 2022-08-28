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
  emits: ["invalid-feedback-end"],
  props: {
    variant: {
      type: String,
      default: "default",
      validator(value) {
        return ["default", "primary", "secondary", "sucess"].includes(value);
      }
    },
    size: {
      type: String,
      default: "l",
      validator(value) {
        return ["xs", "s", "m", "l", "xl"].includes(value);
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
    },
    invalidFeedback: {
      type: Boolean,
      default: false
    },
  },
  data() {
    return {
      showInvalidFeedback: false,
      invalidFeedbackTimer: null
    }
  },
  watch: {
    invalidFeedback(val) {
      this.showInvalidFeedback = val;
      clearTimeout(this.invalidFeedbackTimer)

      this.invalidFeedbackTimer = setTimeout(() => {
        this.$emit("invalid-feedback-end")
        this.showInvalidFeedback = false;
      }, 300);
    }
  },
  computed: {
    altButtonClass() {
      const res = [this.variant + "-variant", "size-" + this.size]
      res.push(this.stretched ? "stretched" : "")
      res.push(this.showInvalidFeedback ? "invalid-feedback" : "")

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

  @media screen and (max-width: 1200px) {
    font-size: 18px;
    padding: 11px 20px;
  }

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

.size-xl {
  padding: 16px 28px;
  font-size: 24px;
}

.size-l {
  padding: 14px 26px;
  font-size: 20px;
}

.size-m {
  padding: 12px 24px;
  font-size: 18px;
}

.size-s {
  padding: 10px 20px;
  font-size: 16px;
}

.size-xs {
  padding: 8px 16px;
  font-size: 14px;
}

.success-variant {
  background: var(--success);
}

.invalid-feedback {
  background-color: var(--danger);
  outline: 10px solid rgba(228, 62, 62, .5);
  animation: shake-x .075s ease infinite;
}
</style>
