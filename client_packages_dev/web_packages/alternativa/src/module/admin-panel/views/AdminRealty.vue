<template>
  <n-collapse>
    <n-collapse-item title="Квартиры">
      <n-button>
        Создать многоквартирный дом
      </n-button>
      <n-divider></n-divider>
      TODO: Управление квартирами
    </n-collapse-item>
    <n-collapse-item title="Дома">
      <n-button @click="isCreateHouseShown = true">
        Создать дом
      </n-button>
    </n-collapse-item>
  </n-collapse>

  <n-divider/>

  <n-modal v-model:show="isCreateHouseShown" closable>
    <n-card
        closable
        @close="isCreateHouseShown = false"
        class="width-md"
        title="Создание дома"
    >
      <n-form
          :model="creteHouseInfo"
      >
        <n-form-item
            label="Прототип дома"
            required
            path="interiorGuid"
        >
          <n-select
              v-model:value="creteHouseInfo.prototypeGuid"
              :options="housePrototypes"
              :loading="housePrototypeListLoading"
          />
        </n-form-item>
        <n-form-item
            label="Точка входа"
            required
            path="position"
        >
          <n-input-number
              v-model:value="creteHouseInfo.position.x"
              placeholder="X"
              class="mr-5"
          />
          <n-input-number
              v-model:value="creteHouseInfo.position.y"
              placeholder="Y"
              class="mr-5"
          />
          <n-input-number
              v-model:value="creteHouseInfo.position.z"
              placeholder="Z"
              class="mr-5"
          />
          <n-button
              type="primary"
              secondary
              @click="useCurrentPosition"
          >
            <n-icon>
              <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 24 24">
                <g fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                  <circle cx="12" cy="11" r="3"></circle>
                  <path d="M17.657 16.657L13.414 20.9a2 2 0 0 1-2.827 0l-4.244-4.243a8 8 0 1 1 11.314 0z"></path>
                </g>
              </svg>
            </n-icon>
          </n-button>
        </n-form-item>
      </n-form>

      <n-button block type="primary" @click="createSingleHouse">
        Создать дом
      </n-button>
    </n-card>
  </n-modal>
</template>

<script setup lang="ts">
import {computed, ref} from "vue";
import {storeToRefs} from "pinia";
import {useAdminPanelRealtyStore} from "@/store/adminPanelRealty";
import {usePlayerStore} from "@/store/playerStore";
import {useAdminStore} from "@/store/adminPanel";

const isCreateHouseShown = ref(false)

const {player} = storeToRefs(usePlayerStore())
const {requestPlayerPositionAsync} = usePlayerStore()
const {housePrototypeList, housePrototypeListLoading} = storeToRefs(useAdminPanelRealtyStore())
const {loadHousePrototypes} = useAdminPanelRealtyStore()
const {altMpAdmin} = storeToRefs(useAdminStore())


loadHousePrototypes();

const housePrototypes = computed(() => {
  return housePrototypeList.value.map(housePrototype => {
    return {
      label: housePrototype.name + ` [${housePrototype.priceSegment}] / $${housePrototype.governmentPrice} / ${housePrototype.parkingPlaces} ПМ`,
      value: housePrototype.guid
    }
  })
})

const creteHouseInfo = ref({
  prototypeGuid: '',
  position: {
    x: 0,
    y: 0,
    z: 0
  },
})

const useCurrentPosition = () => {
  requestPlayerPositionAsync().then((position: any) => {
    creteHouseInfo.value.position.x = position.x
    creteHouseInfo.value.position.y = position.y
    creteHouseInfo.value.position.z = position.z
  })
}

const createSingleHouse = () => {
  console.log(creteHouseInfo.value)
  altMpAdmin.value.triggerServer("CreateSingleHouse", JSON.stringify(creteHouseInfo.value))
}
</script>

<style scoped>

</style>
