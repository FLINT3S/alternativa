import {defineStore} from "pinia";
import {altMP} from "@/connect/events/altMP";
import type {Ref} from "vue";
import {computed, ref} from "vue";
import type {OnlineCharacters} from "@/module/admin-panel/data/types";
import type {AdministrateCharacter} from "@/module/admin-panel/data/AdministrateCharacter";
import type {AdminActions} from "@/module/admin-panel/data/AdminMethodDescriptor";
import {AdminMethodDescriptor} from "@/module/admin-panel/data/AdminMethodDescriptor";

export const mockPlayers = [
  {
    staticId: 1,
    fullname: "John Doe",
  },
  {
    staticId: 2,
    fullname: "Alex Smith",
  },
  {
    staticId: 3,
    fullname: "Bob Marley",
  }
]

const mockPlayersMethods = [
  {
    "name": "Получить персонажей в онлайн",
    "command": "GetOnlineCharacters",
    "description": "",
    "params": []
  },
  {
    "name": "Получить подробную информацию об игроке",
    "command": "GetCharacterMainInfo",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Убить игрока",
    "command": "KillPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Воскресить игрока",
    "command": "ResurrectPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Установить здоровье игрока",
    "command": "SetPlayerHealth",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Unnamed parameter",
        "description": ""
      }
    ]
  },
  {
    "name": "Установить броню игрока",
    "command": "SetPlayerArmor",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Unnamed parameter",
        "description": ""
      }
    ]
  },
  {
    "name": "Телепортировать игрока сюда",
    "command": "TeleportPlayerHere",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Телепортироваться к игроку",
    "command": "TeleportToPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Телепортировать игрока в точку",
    "command": "TeleportPlayerToPoint",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Телепортировать игрока в локацию",
    "command": "TeleportPlayerToLocation",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Изменить деньги игрока",
    "command": "ChangePlayerMoney",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Сумма",
        "description": ""
      }
    ]
  },
  {
    "name": "Временно забанить игрока",
    "command": "TemporaryBanPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Причина",
        "description": ""
      },
      {
        "type": "number",
        "name": "Число секунд",
        "description": ""
      },
      {
        "type": "string",
        "name": "Сообщение",
        "description": ""
      }
    ]
  },
  {
    "name": "Насовсем забанить игрока",
    "command": "PermanentBanPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Причина",
        "description": ""
      },
      {
        "type": "string",
        "name": "Сообщение",
        "description": ""
      }
    ]
  },
  {
    "name": "Заглушить игрока",
    "command": "MutePlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Получить данные об игроке",
    "command": "GetPlayerStats",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Остановить анимации/выкинуть из транспорта игрока",
    "command": "SlapPlayer",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Получить список наказаний игрока",
    "command": "GetPunishments",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Починить машину игроку",
    "command": "RepairCar",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  },
  {
    "name": "Выдать оружие игроку",
    "command": "GetWeapon",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      },
      {
        "type": "number",
        "name": "Оружие",
        "description": ""
      },
      {
        "type": "number",
        "name": "Число снарядов",
        "description": ""
      }
    ]
  },
  {
    "name": "Отобрать оружие у игрока",
    "command": "RemoveWeapon",
    "description": "",
    "params": [
      {
        "type": "number",
        "name": "Статический ID игрока",
        "description": ""
      }
    ]
  }
]


export const useAdminStore = defineStore('admin', () => {
  const altMpAdmin: Ref<altMP> = ref(new altMP("AdminPanel", "1"))
  const fullOnlineCharactersList: Ref<OnlineCharacters> = ref(mockPlayers)
  const onlineCharactersListFilter: Ref<string> = ref('')
  const selectedCharacter: Ref<AdministrateCharacter | null> = ref(null)
  const availableMethods: Ref<AdminActions> = ref({players: []})

  const onlineCharactersList = computed(() => {
    return fullOnlineCharactersList.value.filter((character) =>
      (character.fullname + character.staticId).toLowerCase().includes(onlineCharactersListFilter.value.toLowerCase())
    )
  })

  function loadOnlineCharactersList() {
    altMpAdmin.value.triggerServerWithAnswerPending("GetOnlineCharacters")
      .then(([characters]) => {
        fullOnlineCharactersList.value = JSON.parse(characters as string)
      })
  }

  function loadAvailableMethods() {
    // altMpAdmin.value.triggerServerWithAnswerPending("GetAvailableMethods")
    //   .then(([methods]) => {
    //     const parsedMethods = JSON.parse(methods as string)
    //
    //     availableMethods.value.players = parsedMethods.Player.map((method: any) => new AdminMethodDescriptor(method))
    //   })
      // @ts-ignore
    availableMethods.value.players = mockPlayersMethods.map((method: any) => new AdminMethodDescriptor(method))
  }

  function initAdminPanel() {
    loadOnlineCharactersList()
    loadAvailableMethods()
  }

  return {
    altMpAdmin,
    fullOnlineCharactersList,
    onlineCharactersList,
    onlineCharactersListFilter,
    selectedCharacter,
    availableMethods,

    loadOnlineCharactersList,
    initAdminPanel
  }
})
