<template>
  <n-card class="width-md">
    <n-space vertical>
      <n-input
          v-model:value="characterCreationData.name"
          placeholder="Имя"
      />
      <n-input
          v-model:value="characterCreationData.surname"
          placeholder="Фамилия"
      />
      <n-input-number
          v-model:value="characterCreationData.age"
          placeholder="Возраст (сколько лет?)"
      />
      <n-button block @click="onCreateCharacter">
        Создать персонажа
      </n-button>
    </n-space>
  </n-card>
</template>

<script lang="ts" setup>
import {NButton, NCard, NInput, NInputNumber, NSpace} from 'naive-ui'
import type {Ref} from "vue";
import {onUnmounted, ref} from "vue";
import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";
import {useCharacterManagerStore} from "@/store/charMan";
import type {CharacterData} from "../data/CharacterData"
import type {altMP} from "@/connect/events/altMP";

const {isOverlayBackdropVisible, overlayBackdropTransition} = storeToRefs(useRootStore())
const prevOverlayValue = ref()
const prevBackTransValue = ref()
const {
  characterCreationData,
  altMpCm
}: { characterCreationData: Ref<CharacterData>, altMpCm: Ref<altMP> } = storeToRefs(useCharacterManagerStore())

const onCreateCharacter = () => {
  altMpCm.value.triggerClient("CharacterCreatedSubmit", characterCreationData.value.commonInfo)
}

prevOverlayValue.value = isOverlayBackdropVisible.value
prevBackTransValue.value = overlayBackdropTransition.value

isOverlayBackdropVisible.value = false
// overlayBackdropTransition.value = false

onUnmounted(() => {
  overlayBackdropTransition.value = prevBackTransValue.value
  // isOverlayBackdropVisible.value = prevOverlayValue.value
})
</script>

<style scoped>

</style>
