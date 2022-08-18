import {createRouter, createWebHashHistory, RouteRecordRaw} from 'vue-router'
import HomeView from '../views/AuthorizationView.vue'
import WelcomeView from '../views/WelcomeView.vue'
import LoaderView from '../views/LoaderView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: "/loader",
    name: "loader",
    component: LoaderView
  },
  {
    path: '/welcome',
    name: 'Welcome',
    component: WelcomeView
  },
  {
    path: '/',
    name: 'home',
    component: HomeView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
