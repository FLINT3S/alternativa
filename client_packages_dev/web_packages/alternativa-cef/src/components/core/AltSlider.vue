<template>
  <div class="alt-slider__range d-flex">
    <span v-if="showRange" class="alt-slider__range__min me-2 my-auto">{{ min }}</span>
    <button class="control-btn me-1" @click="onInput({target: {value: modelValue - parseFloat(step)}})">
      <span class="material-icons-round">
        remove
      </span>
    </button>
    <div class="alt-slider__container w-100 d-flex position-relative">
      <div v-if="showValueTooltip" class="position-absolute value-tooltip" :style="'left: calc(' + valueTooltipPosition + '% - 25px)'">
        {{currentValue}}
      </div>
      <div class="slider-line"></div>
      <input
          ref="input"
          :max="max + ''"
          :min="min + ''"
          :step="step + ''"
          :value="currentValue"
          class="slider my-auto"
          type="range"
          @input="onInput"
      >
    </div>
    <button class="control-btn ms-1" @click="onInput({target: {value: modelValue + parseFloat(step)}})">
      <span class="material-icons-round">
        add
      </span>
    </button>
    <span v-if="showRange" class="alt-slider__range__max ms-2 my-auto">{{ max }}</span>
  </div>
</template>

<script>
import {defineComponent} from "vue";

export default defineComponent({
  props: {
    modelValue: {
      type: Number,
    },
    min: {
      default: 0
    },
    max: {
      default: 100
    },
    step: {
      default: 1,
    },
    showRange: {
      type: Boolean,
      default: false
    },
    showValueTooltip: {
      type: Boolean,
      default: false
    },
    debounce: {
      type: Number,
      default: 0
    }
  },
  data() {
    return {
      currentValue: null,
      debounceTimer: null
    }
  },
  computed: {
    valueTooltipPosition() {
      return (this.currentValue - this.min) / (this.max - this.min) * 100;
    }
  },
  methods: {
    onInput(e) {
      this.currentValue = parseFloat(e.target.value)
      if (this.debounce) {
        clearTimeout(this.debounceTimer);
        this.debounceTimer = setTimeout(() => {
          this.$emit('update:modelValue', this.currentValue)
        }, this.debounce)
      } else {
        this.$emit('update:modelValue', this.currentValue)
      }
    }
  },
  mounted() {
    this.currentValue = parseInt(this.modelValue)
  }
})
</script>

<style lang="scss" scoped>
.alt-slider__container {
  .slider-line {
    height: 2px;
    border-radius: 100px;
    background-color: var(--text-secondary);
    width: 100%;
    top: 14px;
    z-index: 0;
    position: absolute;
  }
  .slider {
    -webkit-appearance: none;
    appearance: none;
    width: 100%;
    height: 32px;
    border-radius: 2px;
    background: transparent;
    outline: none;
    -webkit-transition: .2s;
    transition: opacity .2s;

    &::-webkit-slider-thumb {
      -webkit-appearance: none;
      appearance: none;
      width: 15px;
      position: relative;
      z-index: 2;
      height: 15px;
      background: var(--accent-primary);
      cursor: pointer;
      border-radius: 500px;
    }

    &:hover + ::-moz-range-thumb {
      opacity: 1;
    }
  }
}

.value-tooltip {
  text-align: center;
  width: 50px;
  top: -30px;
  background: rgba(0, 0, 0, .6);
  border-radius: 5px;
  height: 0;
  padding: 0;
  overflow: hidden;
  opacity: 0;
  transition: opacity .3s ease;
}

.alt-slider__container:hover {
  .value-tooltip {
    padding: 5px;
    height: auto;
    opacity: 1;
  }
}

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
