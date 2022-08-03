import {createApp} from 'vue'
import App from './AdminPanel.vue'
import router from './router'
import store from './store'
import "@/assets/style/bootstrap-utilities.min.css"
import "@/assets/style/bootstrap-reboot.min.css"
import {connectRage} from "@/connect/connectRageVuePlugin";


const moduleName = "SettingsPanel"
const moduleVersion = "0.0.1"

createApp(App).use(connectRage, {moduleName, moduleVersion}).use(store).use(router).mount('#app')
