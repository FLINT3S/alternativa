import {defineStore} from "pinia";
import {altMP} from "@/connect/events/altMP";
import type {Ref} from "vue";
import {ref} from "vue";
import type {AdminMethods} from "@/module/admin-panel/data/AdminMethodDescriptor";


// const mockPlayersMethods = {
//   "Общие Методы": [
//     {
//       "name": "Получить персонажей в онлайн",
//       "command": "GetOnlineCharacters",
//       "description": "",
//       "params": []
//     },
//     {
//       "name": "Получить подробную информацию об игроке",
//       "command": "GetCharacterMainInfo",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     }
//   ],
//   "Состояние игрока": [
//     {
//       "name": "Убить игрока",
//       "command": "KillPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Воскресить игрока",
//       "command": "ResurrectPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Установить здоровье игрока",
//       "command": "SetPlayerHealth",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Unnamed parameter",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Установить броню игрока",
//       "command": "SetPlayerArmor",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Unnamed parameter",
//           "description": ""
//         }
//       ]
//     }
//   ],
//   "Местоположение": [
//     {
//       "name": "Телепортировать игрока сюда",
//       "command": "TeleportPlayerHere",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Телепортироваться к игроку",
//       "command": "TeleportToPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Телепортировать игрока в точку",
//       "command": "TeleportPlayerToPoint",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Телепортировать игрока в локацию",
//       "command": "TeleportPlayerToLocation",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     }
//   ],
//   "Финансы": [
//     {
//       "name": "Изменить деньги игрока",
//       "command": "ChangePlayerMoney",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Сумма",
//           "description": ""
//         }
//       ]
//     }
//   ],
//   "Управление": [
//     {
//       "name": "Временно забанить игрока",
//       "command": "TemporaryBanPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Причина",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Число секунд",
//           "description": ""
//         },
//         {
//           "type": "string",
//           "name": "Сообщение",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Насовсем забанить игрока",
//       "command": "PermanentBanPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Причина",
//           "description": ""
//         },
//         {
//           "type": "string",
//           "name": "Сообщение",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Заглушить игрока",
//       "command": "MutePlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Остановить анимации/выкинуть из транспорта игрока",
//       "command": "SlapPlayer",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Получить список наказаний игрока",
//       "command": "GetPunishments",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     }
//   ],
//   "Другое": [
//     {
//       "name": "Получить данные об игроке",
//       "command": "GetPlayerStats",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Починить машину игроку",
//       "command": "RepairCar",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Выдать оружие игроку",
//       "command": "GetWeapon",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Оружие",
//           "description": ""
//         },
//         {
//           "type": "number",
//           "name": "Число снарядов",
//           "description": ""
//         }
//       ]
//     },
//     {
//       "name": "Отобрать оружие у игрока",
//       "command": "RemoveWeapon",
//       "description": "",
//       "params": [
//         {
//           "type": "number",
//           "name": "Статический ID игрока",
//           "description": ""
//         }
//       ]
//     }
//   ]
// }


export const useAdminStore = defineStore('admin', () => {
  const altMpAdmin: Ref<altMP> = ref(new altMP("AdminPanel", "1"))
  const availableMethods: Ref<AdminMethods> = ref({players: {}})

  function loadAvailableMethods() {
    altMpAdmin.value.triggerServerWithAnswerPending("GetAvailableMethods")
      .then(([methods]) => {
        availableMethods.value = JSON.parse(methods as string) as AdminMethods
      })

    // if (import.meta.env.DEV) {
    // //   @ts-ignore
    //   availableMethods.value.players = mockPlayersMethods
    // }
  }

  function initAdminPanel() {
    loadAvailableMethods()
  }

  return {
    altMpAdmin,
    availableMethods,

    initAdminPanel
  }
})
