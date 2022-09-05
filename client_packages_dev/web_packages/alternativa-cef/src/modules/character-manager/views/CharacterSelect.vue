<template>
  <alt-card>
    <alt-input
        v-model="characterId"
        placeholder="ID персонажа"
        size="l"
    />
    <alt-button :invalid-feedback="badFeedback"
                size="m"
                @click="onSelectCharacter"
                @invalid-feedback-end="badFeedback = false"
    >
      Выбрать персонажа
    </alt-button>
    <hr>
    <alt-button
        size="m"
        @click="onCreateCharacter"
    >
      Создать персонажа
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
      characterId: "",
      badFeedback: false,
    }
  },
  methods: {
    onSelectCharacter() {
      this.badFeedback = true;
      altMpCM.triggerServer('SelectCharacter', this.characterId)
    },
    onCreateCharacter() {
      altMpCM.triggerClient("CreateCharacter")
    }
  }
}
</script>

<style scoped>

</style>
