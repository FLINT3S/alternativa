import {createApp} from 'vue'
import App from './modules/AltApp.vue'
import router from './router'
import store from './store'

import "@/assets/style/main.scss"

import {altMP} from "@/connect/events/altMP";

import VueSlider from 'vue-slider-component'
import 'vue-slider-component/theme/default.css'


import AltUI from "altui"
import "altui/dist/style.css"
import "altui/dist/style/reboot-cef.scss"

// @ts-ignore
import "@/utils/extensions.ts"

// @ts-ignore
window.altMp = new altMP("Root", "1")
// @ts-ignore
window.altMP = window.altMp

// @ts-ignore
createApp(App)
  .use(store)
  .use(router)
  .use(AltUI)
  .component('VueSlider', VueSlider)
  .mount('#app')
