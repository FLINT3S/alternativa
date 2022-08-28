<template>
  <alt-card>
    <alt-input
        placeholder="ID персонажа"
        v-model="characterId"
    />
    <alt-button @click="selectCharacter">
      Выбрать персонажа
    </alt-button>
  </alt-card>
</template>

<script>
import AltCard from "@/components/core/AltCard";
import AltInput from "@/components/core/AltInput";
import AltButton from "@/components/core/AltButton";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";

export default {
  name: "CharacterSelect",
  components: {AltButton, AltInput, AltCard},
  data() {
    return {
      characterId: ""
    }
  },
  methods: {
    selectCharacter() {
      altMpCM.triggerServer('SelectCharacter', this.characterId)
    }
  }
}
</script>

<style scoped>

</style>
