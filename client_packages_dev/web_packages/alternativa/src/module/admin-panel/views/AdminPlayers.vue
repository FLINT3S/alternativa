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
              :render-extra="renderExtraCharacterSelect"
              key-field="staticId"
              label-field="fullname"
              @update:value="onSelectCharacter"
          />
        </n-scrollbar>
      </n-layout-sider>
      <n-layout>
        <n-scrollbar style="max-height: 100%">
          <n-list v-if="selectedCharacter">
            <admin-action v-for="action in availableMethods.players" :action-descriptor="action"></admin-action>
          </n-list>
          <n-result
              v-else
              description="Чтобы продолжить, выбери игрока из списка слева"
              status="info"
              style="margin-top: 24px"
              title="Игрок не выбран"
          />
        </n-scrollbar>
      </n-layout>
    </n-layout>
  </div>
</template>

<script lang="ts" setup>
import {NDivider, NInput, NLayout, NLayoutSider, NList, NMenu, NResult, NScrollbar} from 'naive-ui'
import {useAdminStore} from "@/store/adminPanel";
import {storeToRefs} from "pinia";
import {createElementVNode} from "vue";
import {AdministrateCharacter} from "@/module/admin-panel/data/AdministrateCharacter";
import AdminAction from "@/module/admin-panel/components/AdminAction.vue";

const {
  altMpAdmin,
  onlineCharactersList,
  onlineCharactersListFilter,
  selectedCharacter,
  availableMethods
} = storeToRefs(useAdminStore())

const renderExtraCharacterSelect = (option: any) => {
  return createElementVNode('span', {
    style: {
      color: 'var(--text-color-secondary)',
      fontSize: '12px',
      marginLeft: '8px'
    }
  }, `[${option.staticId}]`)
}

const onSelectCharacter = (characterStaticId: number) => {
  selectedCharacter.value = new AdministrateCharacter(altMpAdmin.value, characterStaticId)
  selectedCharacter.value.load()
}
</script>

<style scoped>

</style>
