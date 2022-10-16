import {defineStore, storeToRefs} from "pinia";
import type {Ref} from "vue";
import {ref} from "vue";
import {useAdminStore} from "@/store/adminPanel";
import type {HousePrototype} from "@/data/HousePrototype";

export const useAdminPanelRealtyStore = defineStore('adminPanelRealty', () => {
  const {altMpAdmin, availableMethods} = storeToRefs(useAdminStore())

  const housePrototypeList: Ref<HousePrototype[]> = ref([])
  const housePrototypeListLoading = ref(false)

  function loadHousePrototypes() {
    housePrototypeListLoading.value = true
    altMpAdmin.value.triggerServerWithAnswerPending("GetHousePrototypes")
      .then(([housePrototypes]) => {
        housePrototypeList.value = JSON.parse(housePrototypes as string)
        housePrototypeListLoading.value = false
      })
      .finally(() => {
        housePrototypeListLoading.value = false
      })
  }

  return {
    housePrototypeList,
    housePrototypeListLoading,
    loadHousePrototypes
  }
})
