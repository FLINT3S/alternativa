<template>
  <div class="creator-appearance">
    <alt-card class="card" style="height: 100%; padding-right: 12px; padding-left: 24px;">
      <h5 class="mb-0">Редактор внешности</h5>

      <div class="section-pills__wrapper">
        <div class="section-pills">
          <alt-pill
              v-for="section in sections"
              :key="section"
              :disabled="section !== activeSection"
              @click="activeSection = section"
          >
            {{ section }}
          </alt-pill>
        </div>
      </div>

      <div class="container">
        <transition mode="out-in" name="fade">
          <component :is="activeSectionComponentName" :key="activeSectionComponentName"
                     :character-data="characterData"></component>
        </transition>
      </div>
    </alt-card>
  </div>
</template>

<script>
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import AltCard from "@/components/core/AltCard";
import AltPill from "@/components/core/AltPill";
import FaceFeatures from "@/modules/character-manager/components/FaceFeatures";
import ParentsEditor from "@/modules/character-manager/components/ParentsEditor";

export default {
  name: "CreatorAppearance",
  components: {AltPill, AltCard, FaceFeatures, ParentsEditor},
  data() {
    return {
      sections: ["Родители", "Внешность", "Особенности"],
      activeSection: "Родители",
    }
  },
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  computed: {
    activeSectionComponentName() {
      switch (this.activeSection) {
        case "Родители":
          return "parents-editor"
        case "Внешность":
          return "face-features"
        case "Особенности":
          return "Features"
        default:
          return "parents-editor"
      }
    }
  }
}
</script>

<style>
.content-scroll {
  padding-right: 12px;
  height: 100%;
  overflow-y: auto;
}
</style>

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
    //padding-right: 12px;
    height: calc(100% - 120px);
    overflow-x: hidden;
    overflow-y: hidden;
  }

  .section-pills__wrapper {
    padding-left: 24px;
    padding-right: 12px;
    margin-top: 12px;
    margin-bottom: 12px;
  }

  .section-pills {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;

    .alt-pill {
      margin: 6px 6px 0 6px;
    }
  }
}
</style>
