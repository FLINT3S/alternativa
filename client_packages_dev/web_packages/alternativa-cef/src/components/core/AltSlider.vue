<template>
  <div class="alt-slider__wrapper d-flex w-100">
    <!--    https://nightcatsama.github.io/vue-slider-component/#/api/props    -->
    <button
        class="control-btn me-2"
        @click="onDecrease"
    >
      <span class="material-icons-round">
        remove
      </span>
    </button>
    <vue-slider
        :model-value="innerValue"
        :interval="interval"
        v-bind="$attrs"
        :min="min"
        :max="max"
        width="100%"
        @update:modelValue="onInput"
    />
    <button
        class="control-btn ms-2"
        @click="onIncrease"
    >
      <span class="material-icons-round">
        add
      </span>
    </button>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  props: {
    modelValue: {
      type: Number,
    },
    debounce: {
      type: Number,
      default: 0,
    },
    interval: {
      type: Number,
      default: 1,
    },
    min: {
      type: Number,
      default: undefined,
    },
    max: {
      type: Number,
      default: undefined,
    },
  },
  data() {
    return {
      debounceTimer: null,
      innerValue: this.modelValue,
    }
  },
  watch: {
    modelValue(value) {
      this.innerValue = value;
    }
  },
  methods: {
    onInput(v) {
      this.innerValue = v
      if (this.debounce) {
        clearTimeout(this.debounceTimer);
        this.debounceTimer = setTimeout(() => {
          this.$emit("update:modelValue", v)
          this.$emit("input", v)
        }, this.debounce)
      } else {
        this.$emit("update:modelValue", v)
        this.$emit("input", v)
      }
    },
    onDecrease() {
      const v = Math.round((this.innerValue - this.interval) * (1 / this.interval)) / (1 / this.interval)
      if (this.min !== undefined && v >= this.min) {
        this.onInput(v)
      }
    },
    onIncrease() {
      const v = Math.round((this.innerValue + this.interval) * (1 / this.interval)) / (1 / this.interval)
      if (this.max !== undefined && v <= this.max) {
        this.onInput(v)
      }
    }
  }
})
</script>

<style lang="scss">
/*Vue Slider style override*/
.alt-slider__wrapper {
  /* rail style */
  .vue-slider-rail {
    background-color: var(--text-secondary);
    border-radius: 15px;
  }

  /* process style */
  .vue-slider-process {
    background-color: var(--accent-primary);
    border-radius: 15px;
  }

  .vue-slider-dot-handle {
    cursor: pointer;
    width: 100%;
    height: 100%;
    border-radius: 50%;
    background-color: #fff;
    box-sizing: border-box;
    box-shadow: 0.5px 0.5px 2px 1px rgba(0, 0, 0, 0.32);
    transition: all .3s ease;
  }
  .vue-slider-dot-handle-focus {
    background-color: var(--accent-primary);
    box-shadow: 0px 0px 1px 2px rgba(52, 152, 219, 0.36);
  }


  .vue-slider-dot-tooltip-inner {
    font-size: 14px;
    white-space: nowrap;
    padding: 2px 5px;
    min-width: 20px;
    text-align: center;
    color: #fff;
    border-radius: 5px;
    border-color: var(--accent-primary);
    background-color: var(--accent-primary);
    box-sizing: content-box;
  }
}
</style>

<style lang="scss" scoped>
.control-btn {
  aspect-ratio: 1;
  display: flex;
  border-radius: 100px;
  width: 20px;
  height: 20px;
  outline: none;
  border: none;
  background-color: var(--accent-primary);
  color: white;
  padding: 0;
  margin-top: auto;
  margin-bottom: auto;

  span {
    margin: auto;
    line-height: 0;
    font-size: 12px;
  }
}
</style>
