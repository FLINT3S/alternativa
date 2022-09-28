<template>
  <n-card class="width-xl" closable title="Админка">
    <n-tabs animated type="line">
      <n-tab-pane name="quick" tab="Главная">
        <AdminIndex/>
      </n-tab-pane>
      <n-tab-pane name="players" tab="Игроки">
        <AdminPlayers/>
      </n-tab-pane>
      <n-tab-pane name="env" tab="Окружение">
        Hey Jude
      </n-tab-pane>
      <n-tab-pane name="other" tab="Другое">
        Другое
      </n-tab-pane>
    </n-tabs>
  </n-card>
</template>

<script lang="ts" setup>
import {NCard, NTabPane, NTabs} from 'naive-ui'
import AdminIndex from "@/module/admin-panel/views/AdminIndex.vue";
import AdminPlayers from "@/module/admin-panel/views/AdminPlayers.vue";
import {useAdminStore} from "@/store/adminPanel";

const {initAdminPanel} = useAdminStore()

initAdminPanel()
</script>

<style scoped>

</style>
