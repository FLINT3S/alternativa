import {createRouter, createWebHashHistory, RouteRecordRaw} from 'vue-router'
import CharacterMenu from "@/modules/character-manager/views/CharacterMenu.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: CharacterMenu
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
