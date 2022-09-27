<template>
  <div v-if="selectedCharacter && selectedCharacter.loading" class="mt-15">
    <n-skeleton :repeat="2" round text/>
    <n-skeleton round style="width: 60%" text/>
  </div>

  <div v-else-if="selectedCharacter !== null" class="mt-15">
    <div class="d-flex justify-content-space-between">
      <div class="w-100 mr-30">
        <n-space align="center" class="w-100" size="small">
          <n-h2 class="mb-0">
            {{ selectedCharacter.fullname }}
          </n-h2>
          <span class="text-small">[{{ selectedCharacter.staticId }}]</span>
        </n-space>

        <div class="d-flex align-items-center mt-10">
          <span class="white-space-nowrap align-items-center mr-5 my-auto">HP: </span>
          <n-progress
              :percentage="selectedCharacter.health"
              :show-indicator="false"
              class="my-auto"
              status="success"
              type="line"
          />
        </div>

        <div class="d-flex align-items-center mt-5">
          <span class="white-space-nowrap align-items-center mr-5 my-auto">AP: </span>
          <n-progress
              :percentage="selectedCharacter.armor"
              :show-indicator="false"
              class="my-auto"
              status="info"
              type="line"
          />
        </div>
      </div>

      <n-space size="small" vertical>
        <span class="text-small white-space-nowrap">IP: {{ selectedCharacter.ip }}</span>
        <span class="text-small white-space-nowrap">SCID: {{ selectedCharacter.socialClubId }}</span>
      </n-space>
    </div>
    <n-divider/>
    <div>
      <n-ul align-text>
        <n-li>Время в игре (аккаунт): {{ selectedCharacter.accountInGameTimeFormatted }}</n-li>
        <n-li>Время в игре (персонаж): {{ selectedCharacter.inGameTimeFormatted }}</n-li>
        <n-li>Время последней сессии: {{ selectedCharacter.lastConnectionTimeFormatted }}</n-li>
        <n-li>Админский уровень: {{selectedCharacter.adminLevel}}/10</n-li>
      </n-ul>
    </div>
    <n-divider/>
  </div>
</template>

<script lang="ts" setup>
import {NDivider, NH2, NLi, NProgress, NSkeleton, NSpace, NUl} from 'naive-ui'
import {storeToRefs} from "pinia";
import {useAdminPlayersStore} from "@/store/adminPanelPlayers";

const {selectedCharacter} = storeToRefs(useAdminPlayersStore())
</script>

<style scoped>

</style>
