<template>
  <div>
    <n-layout has-sider style="height: 600px">
      <n-layout-sider bordered content-style="padding-right: 12px" width="200">
        <n-scrollbar style="max-height: 100%">
          <n-input
              v-model:value="onlineCharactersListFilter"
              placeholder="Фильтр игроков"
          />

          <n-divider style="margin-top: 8px; margin-bottom: 6px;"/>

          <n-menu
              :options="onlineCharactersList"
              key-field="staticId"
              label-field="fullname"
              @update:value="onSelectCharacter"
          />
          <!--          <n-list clickable hoverable>-->
          <!--            <character-cell v-for="character in onlineCharactersList" :static-id="character.staticId"-->
          <!--                            @click="onSelectCharacter(character)">-->
          <!--              {{ character.fullName }}-->
          <!--            </character-cell>-->
          <!--          </n-list>-->
        </n-scrollbar>
      </n-layout-sider>
      <n-layout>
        <n-scrollbar style="max-height: 100%">
          <n-list>
            <admin-action v-for="action in adminActionsStore" :action-descriptor="action"></admin-action>
          </n-list>
        </n-scrollbar>
      </n-layout>
    </n-layout>
  </div>
</template>

<script lang="ts" setup>
import {NDivider, NInput, NLayout, NLayoutSider, NList, NMenu, NScrollbar} from 'naive-ui'
import {useAdminStore} from "@/store/adminPanel";
import {storeToRefs} from "pinia";
import AdminAction from "@/module/admin-panel/components/AdminAction.vue";
import {adminActionsStore} from "@/module/admin-panel/data/AdminActions";

const {altMpAdmin, onlineCharactersList, onlineCharactersListFilter, fullOnlineCharactersList} = storeToRefs(useAdminStore())

altMpAdmin.value.triggerServerWithAnswerPending("GetOnlineCharacters").then(([data]) => {
  // @ts-ignore
  fullOnlineCharactersList.value = JSON.stringify(data)
  console.log(data)
})

const onSelectCharacter = (character: any) => {
  console.log(character)
}
</script>

<style scoped>

</style>
