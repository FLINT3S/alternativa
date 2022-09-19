import {createApp} from 'vue'

import App from './App.vue'

import router from './router'
import {createPinia} from 'pinia';

import '@/assets/style/main.scss'
import {altMP} from "@/connect/events/altMP";

declare global {
    interface Window {
        altMp: altMP,
        altMP: altMP,
    }
}

window.altMp = new altMP("Root", "1")
window.altMP = window.altMp

const app = createApp(App)
const pinia = createPinia()

app.use(router)
app.use(pinia)
app.mount('#app')
