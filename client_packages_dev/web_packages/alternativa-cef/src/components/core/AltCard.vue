<template>
  <div class="alt-card" :class="cardClass">
    <slot/>
  </div>
</template>

<script>
export default {
  name: "AltCard",
  props: {
    width: {
      type: String,
      default: "auto",
      validator(value) {
        return ["auto", "medium", "full"].includes(value);
      }
    }
  },
  computed: {
    cardClass() {
      return [this.cardWidthClass].join(" ")
    },
    cardWidthClass() {
      const res = []

      switch (this.width) {
        case "medium":
          res.push("medium-width");
          break;
        case "full":
          res.push("full-width");
          break;
      }

      return res
    }
  }
}
</script>

<style scoped>
.alt-card {
  background: var(--color-background-primary);
  padding: 24px;
  border-radius: 10px;
}

.medium-width {
  width: 540px;
}
</style>
