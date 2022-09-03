<template>
  <div key="Рот" class="features-tab pt-2">
    <face-feature-slider
        v-for="feature in items"
        :key="feature.id"
        :model-value="characterData.faceFeatures[feature.id]"
        @update:modelValue="v => onFaceFeatureChange(feature.id, v)"
    >
      {{ feature.name }}
    </face-feature-slider>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import FaceFeatureSlider from "@/modules/character-manager/components/face/FaceFeatureSlider";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";

export default defineComponent({
  name: "FeaturesTab",
  components: {FaceFeatureSlider},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    },
    items: {
      type: Array,
      required: true
    }
  },
  methods: {
    onFaceFeatureChange(index, value) {
      this.characterData.faceFeatures[index] = value
      altMpCM.triggerClient("UpdateFaceFeature", index, value)
    },
  }
})
</script>

<style scoped>

</style>
