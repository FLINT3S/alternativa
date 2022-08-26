import {createRouter, createWebHashHistory, RouteRecordRaw} from 'vue-router'
import LoginView from '../views/LoginView.vue'
import RegistrationView from '../views/RegistrationView.vue'
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
    path: '/login',
    name: 'home',
    component: LoginView
  },
  {
    path: '/registration',
    name: 'registration',
    component: RegistrationView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
