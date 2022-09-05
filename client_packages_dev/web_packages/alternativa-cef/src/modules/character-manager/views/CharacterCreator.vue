<template>
  <div class="character-creator">
    <creator-common-info :character-data="characterData"/>
    <creator-appearance :character-data="characterData"/>
  </div>
</template>

<script>
import CreatorCommonInfo from "@/modules/character-manager/components/CreatorCommonInfo";
import CreatorAppearance from "@/modules/character-manager/components/CreatorAppearance";
import {mapGetters} from "vuex";

export default {
  name: "CharacterCreator",
  components: {CreatorAppearance, CreatorCommonInfo},
  computed: {
    ...mapGetters(["characterData"])
  }
}
</script>

<style lang="scss" scoped>
.character-creator {
  height: 100vh;
  width: 100vw;
  position: relative;
}
</style>
