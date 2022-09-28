<template>
  <n-collapse-item
      :name="groupName"
      :title="groupName"
      v-if="methods.length"
  >
    <n-card size="small">
      <n-list>
        <n-list-item
            v-for="method in methodsFiltered"
        >
          <admin-method
              :method-descriptor="method"
          />
        </n-list-item>
      </n-list>
    </n-card>
  </n-collapse-item>
</template>

<script lang="ts" setup>
import {NCollapseItem, NList, NListItem, NCard} from "naive-ui";
import type {AdminMethodDescriptor} from "@/module/admin-panel/data/AdminMethodDescriptor";
import AdminMethod from "@/module/admin-panel/components/AdminMethod.vue";
import {computed} from "vue";
import {storeToRefs} from "pinia";
import {useAdminPlayersStore} from "@/store/adminPanelPlayers";

const {groupName, methods} = defineProps<{
  groupName: string,
  methods: AdminMethodDescriptor[],
}>()

const {playersMethodsFilter} = storeToRefs(useAdminPlayersStore())

const a = computed(() => Math.random() + "")

const methodsFiltered = computed(() => {
  return methods.filter(method => method.name.toLowerCase().includes(playersMethodsFilter.value.toLowerCase()))
})
</script>

<style scoped>

</style>
