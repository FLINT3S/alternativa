<template>
  <div class="face-features content-scroll">
    <face-feature-slider
        v-for="(feature, index) in featureNames"
        :key="feature"
        :model-value="characterData.faceFeatures[index]"
        @update:modelValue="v => onFaceFeatureChange(index, v)"
    >
      {{ feature }}
    </face-feature-slider>
  </div>
</template>

<script>
import FaceFeatureSlider from "@/modules/character-manager/components/FaceFeatureSlider";
import {featureNames} from "@/modules/character-manager/data/creatorData";
import {defineComponent} from "vue";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";

export default defineComponent({
  name: "FaceFeatures",
  components: {FaceFeatureSlider},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  data() {
    return {
      featureNames: featureNames,
    }
  },
  methods: {
    onFaceFeatureChange(index, value) {
      this.characterData.faceFeatures[index] = value
      altMpCM.triggerClient("UpdateFaceFeature", index, value)
    }
  }
})
</script>

<style scoped>

</style>
