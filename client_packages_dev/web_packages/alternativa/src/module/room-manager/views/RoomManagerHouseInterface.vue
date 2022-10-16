<template>
  <n-card class="width-lg" title="Интерфейс дома">
    <p>{{ JSON.stringify(houseData) }}</p>
    <n-button @click="enterToHouse">
      Войти в дом '{{houseId}}'
    </n-button>
  </n-card>
</template>

<script setup lang="ts">
import {storeToRefs} from "pinia";
import {useRoomManagerStore} from "@/store/roomManager";
import {useRouter} from "vue-router";
import {ref} from "vue";
import {parseJson} from "@/data/parseJson";

const {altMpRoomManager} = storeToRefs(useRoomManagerStore());

const router = useRouter();
const houseId = router.currentRoute.value.params.houseId as string;

const enterToHouse = () => {
  altMpRoomManager.value.triggerServer("EnterToHouse", houseId as string);
}

const houseData = ref(null)

const loadHouseData = () => {
  altMpRoomManager.value.triggerServerWithAnswerPending("GetHouseData", houseId)
      .then(([houseDataJson]) => {
        houseData.value = JSON.parse(houseDataJson as string)
      })
}

loadHouseData()

</script>

<style scoped>

</style>
