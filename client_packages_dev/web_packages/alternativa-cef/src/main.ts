import {createApp} from 'vue'
import App from './modules/AltApp.vue'
import router from './router'
import store from './store'
import "@/assets/style/bootstrap/bootstrap-utilities.min.css"
import "@/assets/style/bootstrap/bootstrap-reboot.min.css"
import "@/assets/style/main.scss"
import {altMP} from "@/connect/events/altMP";

// @ts-ignore
window.altMp = new altMP("Root", "1")
// @ts-ignore
window.altMP = window.altMp

createApp(App).use(store).use(router).mount('#app')
