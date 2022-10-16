import {defineStore} from "pinia";
import {ref} from "vue";
import {altMP} from "@/connect/events/altMP";

export const useRoomManagerStore = defineStore('roomManager', () => {
  const altMpRoomManager = ref(new altMP('RoomManager', '1'));

  return {
    altMpRoomManager
  }
})
