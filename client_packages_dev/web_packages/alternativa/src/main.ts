import {createApp} from 'vue'

import App from './App.vue'

import router from './router'
import {createPinia} from 'pinia';

import '@/assets/style/main.scss'
import {altMP} from "@/connect/events/altMP";

import * as Sentry from "@sentry/vue";
import {BrowserTracing} from "@sentry/tracing";
import {
  NButton,
  NCard,
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

app.component("n-card", NCard)
app.component("n-tabs", NTabs)
app.component("n-tab-pane", NTabPane)
app.component("n-button", NButton)
app.component("n-h1", NH1)
app.component("n-h2", NH2)
app.component("n-h3", NH3)
app.component("n-h4", NH4)
app.component("n-text", NText)
app.component("n-input", NInput)
app.component("n-divider", NDivider)
app.component("n-space", NSpace)
app.component("n-collapse", NCollapse)
app.component("n-collapse-item", NCollapseItem)
app.component("n-modal", NModal)
app.component("n-select", NSelect)
app.component("n-form", NForm)
app.component("n-form-item", NFormItem)
app.component("n-input-number", NInputNumber)
app.component("n-icon", NIcon)


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

app.use(router)
app.use(pinia)
app.mount('#app')
