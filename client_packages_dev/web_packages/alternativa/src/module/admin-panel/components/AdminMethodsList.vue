<template>
  <n-input
      v-model:value="playersMethodsFilter"
      clearable
      placeholder="Поиск по методам"
      class="mb-15"
  />
  <n-collapse v-model:expanded-names="expandedCollapseNames">
    <admin-methods-collapse-group
        v-for="groupName in availableMethodsKeys"
        :group-name="groupName"
        :methods="availableMethods[groupName]"
    />
  </n-collapse>
</template>

<script lang="ts" setup>
import {NCollapse, NInput} from "naive-ui";
import AdminMethodsCollapseGroup from "@/module/admin-panel/components/AdminMethodsCollapseGroup.vue";
import type {AdminMethodsGroup} from "@/module/admin-panel/data/AdminMethodDescriptor";
import {storeToRefs} from "pinia";
import {useAdminPlayersStore} from "@/store/adminPanelPlayers";

const {availableMethods} = defineProps<{
  availableMethods: AdminMethodsGroup
}>()
const availableMethodsKeys = Object.keys(availableMethods)

const {playersMethodsFilter, expandedCollapseNames} = storeToRefs(useAdminPlayersStore())
</script>

<style scoped>

</style>
