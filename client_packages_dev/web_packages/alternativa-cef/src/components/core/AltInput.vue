<template>
  <div class="alt-input__content">
    <div :class="altInputClasses" class="alt-input__wrapper d-flex">
      <input
          :placeholder="placeholder"
          :type="fieldType"
          :value="inputValue"
          autocomplete="off"
          class="alt-input"
          @blur="onBlur"
          @focus="onFocus"
          @input.prevent="onInput"
          @keypress.enter="$emit('enter')"
          ref="input"
      >

      <div class="validation-tooltip" v-if="showValidationTooltip" v-show="validation.$errors && validation.$errors.length">
        <div class="tooltip-icon d-flex">
          <span class="material-icons-round m-auto">error_outline</span>
        </div>
        <div class="tooltip-content">
          <div v-if="inputError" class="tooltip-content__item mb-1">
            {{inputError}}
          </div>
          <div v-for="error in validation.$errors" :key="error.$uid" class="tooltip-content__item mb-1">
            {{error.$message}}
          </div>
        </div>
      </div>

      <div class="password-show" v-if="type === 'password' && !noShowPassword">
        <span class="material-icons-round my-auto" @mousedown="onShowPassword" @mouseup="onShowPassword">
          visibility
        </span>
      </div>
    </div>
    <div class="alt-input__caption" :class="{'show': isCaptionShow, ...altInputClasses}" :style="{textAlign: captionAlign}">
      {{caption}}
    </div>
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
    },
    validation: {
      type: Object,
      default: null
    },
    showValidationTooltip: {
      type: Boolean,
      default: false
    },
    noShowPassword: {
      type: Boolean,
      default: false
    },
    debounce: {
      type: Number,
      default: 0
    },
    inputState: {
      type: String,
      default: "default"
    },
    inputError: {
      type: String,
      default: ""
    },
    caption: {
      type: String,
      default: ""
    },
    captionAlign: {
      type: String,
      default: "left"
    },
    pattern: {
      type: RegExp,
      default: null
    },
    showCaptionOnFocus: {
      type: Boolean,
      default: false
    },
    showErrorOnFocus: {
      type: Boolean,
      default: false
    },
    showValidOnFocus: {
      type: Boolean,
      default: false
    },
  },
  data() {
    return {
      inputValue: this.modelValue,
      focused: false,
      debounceTimer: null
    }
  },
  watch: {
    modelValue: {
      handler: function (newValue) {
        this.inputValue = newValue;
      },
      immediate: true
    }
  },
  computed: {
    fieldType() {
      return this.type;
    },
    altInputClasses() {
      return {
        "stretched": this.stretched,
        "focused": this.focused,
        "invalid": this.isInputInvalid,
        "valid": this.isInputValid,
      }
    },
    isCaptionShow() {
      return this.caption.length > 0 && (this.showCaptionOnFocus ? this.focused : true);
    },
    isInputInvalid() {
      if (this.showErrorOnFocus && !this.focused) return false
      if (this.inputState === "default") return this.validation ? (this.validation?.$errors?.length !== 0) : false;

      return this.inputState === "invalid"
    },
    isInputValid() {
      if (this.showValidOnFocus && !this.focused) return false
      return this.inputState === "valid"
    }
  },
  methods: {
    onInput(e) {
      if (this.pattern && this.pattern instanceof RegExp) {
        if (!this.pattern.test(e.target.value)) {
          e.target.value = this.inputValue;
          e.preventDefault()
          return
        }
      }

      this.inputValue = e.target.value;
      this.validation?.$touch();

      if (this.debounce) {
        if (this.debounceTimer) {
          clearTimeout(this.debounceTimer);
        }
        this.debounceTimer = setTimeout(() => {
          this.$emit("update:modelValue", e.target.value);
        }, this.debounce);
      } else {
        this.$emit("update:modelValue", e.target.value);
      }
    },
    onFocus() {
      this.focused = true;
    },
    onBlur() {
      this.focused = false;
    },
    onShowPassword() {
      this.$refs.input.type = this.$refs.input.type === "password" ? "text" : "password";
    }
  }
})
</script>

<style lang="scss" scoped>
.alt-input__wrapper {
  position: relative;
  padding: 10px 14px;
  border: 1px solid var(--color-background-tertiary);
  background: var(--color-background-secondary);
  border-radius: 5px;
  transition: all .3s ease;
  outline-color: var(--accent-primary);

  @media screen and (max-width: 1200px) {
    padding: 8px 10px;
  }

    input {
    font-size: 18px;

    @media screen and (max-width: 1200px) {
      font-size: 16px;
    }

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
    //outline: 1px solid var(--accent-primary);
    border-color: var(--accent-primary);
  }

  &.invalid {
    border-color: var(--danger);
  }

  &.valid {
    border-color: var(--success);
  }
}

.password-show span {
  color: var(--text-secondary)
}

.validation-tooltip, .password-show {
  position: absolute;
  right: 0;
  height: 100%;
  width: 40px;
  top: 0;
  display: flex;
  justify-content: center;
  align-content: center;
  background: linear-gradient(to right, transparent, var(--color-background-secondary) 10%);

  .tooltip-icon {
    color: var(--danger);
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

.alt-input__caption {
  font-size: 12px;
  color: var(--text-secondary);
  height: 0;
  opacity: 0;
  transition: all .3s ease;
  margin-top: 0;
  line-height: 1;

  &.show {
    margin-top: 4px;
    height: 12px;
    opacity: 1;
  }

  &.valid {
    color: var(--success);
  }

  &.invalid {
    color: var(--danger);
  }
}
</style>
