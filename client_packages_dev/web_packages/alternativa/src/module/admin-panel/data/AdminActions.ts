import {AdminActionDescriptor} from "@/module/admin-panel/data/AdminActionDescriptor";

const adminActions: AdminActionDescriptor[] = [
  {
    name: "Убить",
    command: "KellPlayer",
    adminLevel: 2,
    description: "Убить игрока",
    params: []
  },
  {
    name: "Возродить",
    command: "ResurrectPlayer",
    adminLevel: 2,
    description: "",
    params: []
  },
  {
    name: "Установить здоровье",
    command: "SetPlayerHealth",
    adminLevel: 2,
    description: "",
    params: [
      {
        type: "number",
        name: "Здоровье",
        description: "Значение здоровья"
      }
    ]
  },
  {
    name: "Установить броню",
    command: "SetPlayerArmor",
    adminLevel: 2,
    description: "",
    params: [
      {
        type: "number",
        name: "Броня",
        description: "Значение брони"
      }
    ]
  },
  {
    name: "Пееместить к себе",
    command: "TeleportPlayerHere",
    adminLevel: 2,
    description: "Перемещает выбранного игрока в твою текущую позицию",
    params: []
  },
  {
    name: "Переместиться к игроку",
    command: "TeleportToPlayer",
    adminLevel: 2,
    description: "Перемещает тебя к выбранному игроку",
    params: []
  },
  {
    name: "Переместить игрока в точку",
    command: "TeleportPlayerToPoint",
    adminLevel: 2,
    description: "Перемещает выбранного игрока в указанную точку",
    params: [
      {
        type: "string",
        name: "Координаты",
        description: "Координаты в формате '12.32,34,75.23'"
      }
    ]
  },
  {
    name: "Добавить денег",
    command: "ChangePlayerMoney",
    adminLevel: 2,
    description: "Добавляет деньги игроку",
    params: [
      {
        type: "number",
        name: "Сумма",
        description: "Сумма денег"
      }
    ]
  },
  {
    name: "Временный бан",
    command: "TemporaryBanPlayer",
    adminLevel: 2,
    description: "Выдает временный бан",
    params: [
      {
        type: "number",
        name: "Количество минут",
        description: "Время на которое выдается бан"
      }
    ]
  },
  {
    name: "Перманентный бан",
    command: "PermanentBanPlayer",
    adminLevel: 2,
    description: "Выдает перманентный бан",
    params: []
  },
  {
    name: "Замутить",
    command: "MutePlayer",
    adminLevel: 2,
    description: "Запрещает игроку писать/говорить",
    params: [{
      type: "number",
      name: "Количество минут",
      description: "Время на которое выдается мут"
    }]
  },
  {
    name: "Статистика игрока",
    command: "GetPlayerStats",
    adminLevel: 2,
    description: "Показывает статистику игрока",
    params: []
  },
  {
    name: "Слапуть",
    command: "SlapPlayer",
    adminLevel: 2,
    description: "Выкидывает из машины и выключает анимацию",
    params: []
  },
  {
    name: "Починить машину",
    command: "RepairCar",
    adminLevel: 2,
    description: "Чинит машину в которой сидит игрок",
    params: []
  }
]

export const adminActionsStore = adminActions.map((action) =>
  new AdminActionDescriptor(action.name, action.command, action.adminLevel, action.description, action.params)
)
