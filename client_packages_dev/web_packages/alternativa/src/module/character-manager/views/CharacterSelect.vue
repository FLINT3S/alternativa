<template>
  <n-card class="width-md">
    <n-space vertical>
      <n-button v-for="character in ownCharacters" block @click="onSelectCharacter(character.guid)">
        {{ character.firstName }} {{ character.lastName }}, {{ character.age }} - {{ character.inGameTimeFormatted }}
      </n-button>
    </n-space>
    <n-divider/>
    <n-button block @click="onCreateCharacter">
      Создать персонажа
    </n-button>
  </n-card>
</template>

<script lang="ts" setup>
import {NButton, NCard, NDivider, NSpace} from "naive-ui";
import {storeToRefs} from "pinia";
import {useCharacterManagerStore} from "@/store/charMan";
import {parseJson} from "@/data/parseJson";
import {Character} from "@/data/Character";
import type {altMP} from "@/connect/events/altMP";
import type {Ref} from 'vue'

const {
  altMpCm,
  ownCharacters
}: { altMpCm: Ref<altMP>, ownCharacters: Ref<Character[]> } = storeToRefs(useCharacterManagerStore())

const onSelectCharacter = (characterId: string) => {
  altMpCm.value.triggerServer('SelectCharacter', characterId)
}

const onCreateCharacter = () => {
  altMpCm.value.triggerClient("CreateCharacter")
}

altMpCm.value.triggerServerWithAnswerPending("GetOwnCharacters")
    // @ts-ignore
    .then(parseJson)
    .then((characters: any) => {
      ownCharacters.value = characters.map((c: any) => new Character(c))
    })
</script>

<style scoped>

</style>
