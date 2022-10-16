<template>
  <n-card class="width-lg" title="Интерфейс дома">
    <n-button @click="enterToHouse">
      Войти в дом '{{houseId}}'
    </n-button>
  </n-card>
</template>

<script setup lang="ts">
import {storeToRefs} from "pinia";
import {useRoomManagerStore} from "@/store/roomManager";
import {useRouter} from "vue-router";

const {altMpRoomManager} = storeToRefs(useRoomManagerStore());

const router = useRouter();
const houseId = router.currentRoute.value.params.houseId;

const enterToHouse = () => {
  altMpRoomManager.value.triggerServer("EnterToHouse", houseId as string);
}
</script>

<style scoped>

</style>
