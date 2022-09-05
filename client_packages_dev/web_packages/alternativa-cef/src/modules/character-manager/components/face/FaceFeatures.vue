<template>
  <div class="face-features h-100">
    <div class="controls d-flex flex-wrap justify-content-center mb-2 content-no-scroll">
      <alt-pill
          v-for="group in featuresByGroup"
          :key="group.name"
          :disabled="activeTabGroupName !== group.name"
          class="mx-1 mt-1"
          size="small"
          @click="onSelectActiveTab(group)"
      >
        {{ group.name }}
      </alt-pill>
    </div>

    <div class="content-no-scroll mb-3">
      <alt-button size="xs" stretched @click="randomizeGroup(activeGroupId)">
        Рандомизировать {{activeTabGroupName.toLowerCase()}}
      </alt-button>
    </div>

    <transition class="content-scroll" style="padding-bottom: 75px;" mode="out-in" name="fade">
      <features-tab
          key="Рот"
          v-if="activeTabGroupName === 'Рот'"
          :character-data="characterData"
          :items="activeTabGroupItems"
      />
      <features-tab
          key="Нос"
          v-else-if="activeTabGroupName === 'Нос'"
          :character-data="characterData"
          :items="activeTabGroupItems"
      />
      <features-tab
          key="Брови"
          v-else-if="activeTabGroupName === 'Брови'"
          :character-data="characterData"
          :items="activeTabGroupItems"
      />
      <features-tab
          key="Овал лица"
          v-else-if="activeTabGroupName === 'Овал лица'"
          :character-data="characterData"
          :items="activeTabGroupItems"
      />
      <features-tab
          key="Глаза"
          v-else-if="activeTabGroupName === 'Глаза'"
          :character-data="characterData"
          :items="activeTabGroupItems"
      />
    </transition>
  </div>
</template>

<script>
import {featuresByGroup} from "@/modules/character-manager/data/creatorData";
import {defineComponent} from "vue";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import AltPill from "@/components/core/AltPill";
import FeaturesTab from "@/modules/character-manager/components/face/FeaturesTab";
import AltButton from "@/components/core/AltButton";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";

export default defineComponent({
  name: "FaceFeatures",
  components: {AltButton, FeaturesTab, AltPill},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  data() {
    return {
      featuresByGroup: featuresByGroup,
      activeTabGroupName: "Нос",
      activeGroupId: 0,
      activeTabGroupItems: featuresByGroup[0].items,
      updateDebounceTimer: null,
      previousFaceFeatures: []
    }
  },
  watch: {
    "characterData.faceFeatures": {
      handler() {
        clearTimeout(this.updateDebounceTimer);
        this.updateDebounceTimer = setTimeout(() => {
          this.characterData.updateFaceFeaturesData()
        }, 100);
      },
      deep: true
    }
  },
  methods: {
    onSelectActiveTab(group) {
      this.activeTabGroupName = group.name
      this.activeTabGroupItems = group.items
    },
    randomizeGroup() {
      this.characterData.randomizeFeatures(this.activeTabGroupItems.map(g => g.id))
    }
  }
})
</script>

<style scoped>

</style>
