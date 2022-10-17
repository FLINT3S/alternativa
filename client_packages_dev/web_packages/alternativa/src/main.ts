import {createApp} from 'vue'

import App from './App.vue'

import router from './router'
import {createPinia} from 'pinia';

import '@/assets/style/main.scss'
import {altMP} from "@/connect/events/altMP";

import * as Sentry from "@sentry/vue";
import {BrowserTracing} from "@sentry/tracing";
import {
  create,
  NButton,
  NCard,
  NCheckbox,
  NCollapse,
  NCollapseItem,
  NDivider,
  NForm,
  NFormItem,
  NH1,
  NH2,
  NH3,
  NH4,
  NIcon,
  NInput,
  NInputNumber,
  NModal,
  NSelect,
  NSpace,
  NSwitch,
  NTabPane,
  NTabs,
  NText
} from 'naive-ui'

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


if (import.meta.env.MODE === 'production') {
  console.log('Init Sentry')

  Sentry.init({
    app,
    dsn: "https://a2b1b04bb98f4ca6983c77d3d5ec7fd0@o1422619.ingest.sentry.io/6769547",
    integrations: [
      new BrowserTracing({
        routingInstrumentation: Sentry.vueRouterInstrumentation(router),
        tracingOrigins: ["localhost", "my-site-url.com", /^\//],
      }),
    ],
    tracesSampleRate: 1.0,
  });
}

app.use(create({
  components: [
    NButton,
    NCard,
    NCheckbox,
    NCollapse,
    NCollapseItem,
    NDivider,
    NForm,
    NFormItem,
    NH1,
    NH2,
    NH3,
    NH4,
    NIcon,
    NInput,
    NInputNumber,
    NModal,
    NSelect,
    NSpace,
    NTabPane,
    NTabs,
    NText,
    NSwitch,
  ]
}))
app.use(router)
app.use(pinia)
app.mount('#app')
