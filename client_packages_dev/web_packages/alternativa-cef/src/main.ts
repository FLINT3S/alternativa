import {createApp} from 'vue'
import App from './modules/AltApp.vue'
import router from './router'
import store from './store'
import "@/../../../../../alternativa-ui/src/styles/bootstrap/bootstrap-utilities.min.css"
import "@/../../../../../alternativa-ui/src/styles/bootstrap/bootstrap-reboot.min.css"
import "../../../../../alternativa-ui/src/styles/main.scss"
import {altMP} from "@/connect/events/altMP";
import VueSlider from 'vue-slider-component'
import 'vue-slider-component/theme/default.css'
// @ts-ignore
import "@/utils/extensions.ts"

// @ts-ignore
window.altMp = new altMP("Root", "1")
// @ts-ignore
window.altMP = window.altMp

createApp(App).use(store).use(router).component('VueSlider', VueSlider).mount('#app')
