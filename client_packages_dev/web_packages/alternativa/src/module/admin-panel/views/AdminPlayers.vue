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
      <n-layout-content style="padding: 0 12px!important;">
        <n-scrollbar style="max-height: 100%">
          <character-main-info />
          <div v-if="selectedCharacter" class="mt-15">
            <admin-methods-list :available-methods="availablePlayersMethods"/>
          </div>
          <n-result
              v-else
              description="Чтобы продолжить, выбери игрока из списка слева"
              status="info"
              style="margin-top: 24px"
              title="Игрок не выбран"
          />
        </n-scrollbar>
      </n-layout-content>
    </n-layout>
    <n-modal :show="eventResult !== null" closable mask-closable @update:show="() => eventResult = null">
      <n-card style="width: 670px" title="Результат выполнения">
        <n-code>
          {{ eventResult }}
        </n-code>
      </n-card>
    </n-modal>
  </div>
</template>

<script lang="ts" setup>
import {NDivider, NInput, NLayout, NLayoutContent, NLayoutSider, NMenu, NModal, NResult, NScrollbar, NCard, NCode} from 'naive-ui'
import {useAdminStore} from "@/store/adminPanel";
import {storeToRefs} from "pinia";
import {createElementVNode} from "vue";
import {AdministrateCharacter} from "@/module/admin-panel/data/AdministrateCharacter";
import AdminMethodsList from "@/module/admin-panel/components/AdminMethodsList.vue";
import {useAdminPlayersStore} from "@/store/adminPanelPlayers";
import CharacterMainInfo from "@/module/admin-panel/components/CharacterMainInfo.vue";

const {
  onlineCharactersList,
  onlineCharactersListFilter,
  selectedCharacter,
  availablePlayersMethods,
  eventResult
} = storeToRefs(useAdminPlayersStore())

const {altMpAdmin} = storeToRefs(useAdminStore())


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

  // const mockChar = {
  //   "fullname": "123 543",
  //   "age": 12,
  //   "ip": "127.0.0.1",
  //   "login": "1234",
  //   "socialClubId": 65820166,
  //   "inGameTime": 23520,
  //   "accountInGameTime": 23520,
  //   "lastConnectionTime": 1664301060,
  //   "currentPosition": {
  //     "x": 243.49316,
  //     "y": -1459.7046,
  //     "z": 29.334793
  //   },
  //   "health": 100,
  //   "armor": 0,
  //   "adminLevel": 10,
  //   "vipLevel": 0
  // }
  // Object.assign(selectedCharacter.value, mockChar)
}


const {loadOnlineCharactersList} = useAdminPlayersStore()
loadOnlineCharactersList()
</script>

<style scoped>

</style>
