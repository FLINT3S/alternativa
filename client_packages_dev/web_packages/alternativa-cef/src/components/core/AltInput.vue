<template>
  <div class="alt-input__wrapper" :class="altInputClasses">
    <input
        :type="type"
        class="alt-input"
        :placeholder="placeholder"
        :value="inputValue"
        autocomplete="off"
        @input.prevent="onInput"
        @focus="onFocus"
        @blur="onBlur"
    >
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  name: "AltInput",
  props: {
    modelValue: {
      default: ""
    },
    placeholder: {
      type: String,
      default: ""
    },
    type: {
      type: String,
      default: "text"
    },
    stretched: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      inputValue: this.modelValue,
      focused: false
    }
  },
  watch: {
    modelValue: {
      handler: function(newValue) {
        this.inputValue = newValue;
      },
      immediate: true
    }
  },
  computed: {
    altInputClasses() {
      return {
        "stretched": this.stretched,
        "focused": this.focused
      }
    }
  },
  methods: {
    onInput(e) {
      this.inputValue = e.target.value;
      this.$emit("update:modelValue", e.target.value);
    },
    onFocus() {
      this.focused = true;
    },
    onBlur() {
      this.focused = false;
    }
  }
})
</script>

<style scoped lang="scss">
.alt-input__wrapper {
  padding: 10px 14px;
  border: 1px solid var(--color-background-tertiary);
  background: var(--color-background-secondary);
  border-radius: 5px;
  transition: all .3s ease;
  outline-color: var(--accent-primary);

  input {
    font-size: 18px;
    width: 100%;
    padding: 0;
    border: none;
    outline: none;
    color: white;
    background: transparent;
  }

  input::placeholder {
    color: var(--color-background-tertiary);
  }

  &.focused {
    outline: 1px solid var(--accent-primary);
    border-color: var(--accent-primary);
  }
}
</style>
