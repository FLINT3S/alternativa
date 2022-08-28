<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <router-view v-slot="{Component}">
      <transition mode="out-in" name="fade">
        <component :is="Component"/>
      </transition>
    </router-view>
  </alt-overlay>
</template>

<script>
import AltOverlay from "@/components/core/AltOverlay";
import {openOverlayMixin} from "@/mixins/openOverlayMixin";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";

export default {
  name: "CharacterManager",
  components: {AltOverlay},
  mixins: [openOverlayMixin],
  data() {
    return {
      moduleName: "CharacterManager",
      altMp: altMpCM
    }
  }
}
</script>

<style scoped>

</style>
