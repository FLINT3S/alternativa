import {createApp} from 'vue'
import App from './AdminPanel.vue'
import router from './router'
import store from './store'
import "@/assets/style/bootstrap/bootstrap-utilities.min.css"
import "@/assets/style/bootstrap/bootstrap-reboot.min.css"
import {connectRage} from "@/connect/connectRageVuePlugin";


const moduleName = "AdminPanel"
const moduleVersion = "0.0.1"

createApp(App).use(connectRage, {moduleName, moduleVersion}).use(store).use(router).mount('#app')
