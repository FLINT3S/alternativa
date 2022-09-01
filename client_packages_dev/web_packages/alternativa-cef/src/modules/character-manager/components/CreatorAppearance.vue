<template>
  <div class="creator-appearance">
    <alt-card class="card" style="height: 100%; padding-right: 12px; padding-left: 0;">
      <h5 class="mb-0">Редактор внешности</h5>

      <div class="container">
        <div class="content pt-2">
          <face-feature-slider
              v-for="(feature, index) in featureNames"
              :key="feature"
              :model-value="characterData.faceFeatures[index]"
              @update:modelValue="v => onFaceFeatureChange(index, v)"
          >
            {{ feature }}
          </face-feature-slider>
        </div>
      </div>
    </alt-card>
  </div>
</template>

<script>
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import AltCard from "@/components/core/AltCard";
import FaceFeatureSlider from "@/modules/character-manager/components/FaceFeatureSlider";
import {featureNames} from "@/modules/character-manager/data/creatorData";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";

export default {
  name: "CreatorAppearance",
  components: {FaceFeatureSlider, AltCard},
  data() {
    return {
      featureNames: featureNames,
    }
  },
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  methods: {
    onFaceFeatureChange(index, value) {
      this.characterData.faceFeatures[index] = value
      altMpCM.triggerClient("UpdateFaceFeature", index, value)
    }
  }
}
</script>

<style lang="scss" scoped>
.creator-appearance {
  position: absolute;
  top: 20%;
  height: 60vh;
  width: 350px;
  right: 50px;
  text-align: center;

  .card {
    padding-right: 12px;
  }

  .container {
    padding-right: 12px;
    height: calc(100% - 32px);
    overflow-x: hidden;
    overflow-y: auto;

    .content {
      padding-left: 24px;
    }
  }
}
</style>
