<template>
  <div>
    <div>
      Тут будут всякие галочки, правила и соглашения
    </div>
    <alt-button class="mt-3" stretched
                @click="$emit('submit')">
      Начать играть
    </alt-button>
  </div>
</template>

<script>
import AltButton from "@/components/core/AltButton";
export default {
  name: "PolicyConfirm",
  components: {AltButton}
}
</script>

<style scoped>

</style>
