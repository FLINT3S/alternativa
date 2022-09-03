<template>
  <div class="creator-appearance">
    <div class="section-toggles text-start">
      <div :class="{active: activeSection === 'Родители'}" class="section-toggle" @click="activeSection = 'Родители'">
        <span class="material-icons-round">
          supervisor_account
        </span>
      </div>
      <div :class="{active: activeSection === 'Внешность'}" class="section-toggle" @click="activeSection = 'Внешность'">
        <span class="material-icons-round">
          face
        </span>
      </div>
    </div>
    <alt-card class="card" style="height: 100%; padding-right: 12px; padding-left: 24px;">
      <h5 class="mb-0">
        {{ activeSection }}
      </h5>

      <hr class="mb-1 mt-1">

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
import FaceFeatures from "@/modules/character-manager/components/face/FaceFeatures";
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

.content-no-scroll {
  padding-right: 12px;
}
</style>

<style lang="scss" scoped>
.creator-appearance {
  position: absolute;
  top: calc((100% - 650px) / 2);
  height: 650px;
  width: 350px;
  right: 50px;
  text-align: center;

  .card {
    padding-right: 12px;
  }

  .container {
    //padding-right: 12px;
    height: calc(100% - 32px);
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

.section-toggles {
  position: absolute;
  top: 50px;
  left: -50px;
  display: flex;
  flex-direction: column;
  align-items: center;

  .section-toggle {
    display: flex;
    margin-bottom: 4px;
    padding: 8px;
    border-radius: 100px;
    background-color: var(--color-background-primary);
    transition: all .3s ease;

    &.active {
      background-color: var(--accent-primary);
    }

    .material-icons-round {
      font-size: 32px;
    }
  }
}
</style>
