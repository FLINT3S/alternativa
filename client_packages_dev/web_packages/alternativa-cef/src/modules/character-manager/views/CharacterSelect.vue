<template>
  <alt-card>
    <div>
      <alt-button
          v-for="character in ownCharacters"
          :key="character.guid"
          @click="onSelectCharacter(character.guid)"
          stretched
      >
        {{ character.firstName }} {{ character.lastName }}, {{ character.age }} - {{character.inGameTimeFormatted}}
      </alt-button>
    </div>
    <hr>
    <alt-button
        size="m"
        stretched
        @click="onCreateCharacter"
    >
      Создать персонажа
    </alt-button>
  </alt-card>
</template>

<script lang="ts">
import AltCard from "@/components/core/AltCard.vue";
import AltButton from "@/components/core/AltButton.vue";
import {altMpCM, parseJson} from "@/modules/character-manager/data/altMpCM";
import {defineComponent} from "vue";
import {Character} from "@/data/Character";

export default defineComponent({
  name: "CharacterSelect",
  components: {AltButton, AltCard},
  data() {
    return {
      characterId: "",
      badFeedback: false,
      ownCharacters: [] as Character[]
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
  },
  mounted() {
    altMpCM.triggerServerWithAnswerPending("GetOwnCharacters")
        .then(parseJson)
        .then((characters) => {
          console.log(characters)
          this.ownCharacters = characters.map((c: any) => new Character(c))
          console.log(this.ownCharacters)
        })
  }
})
</script>

<style scoped>

</style>
