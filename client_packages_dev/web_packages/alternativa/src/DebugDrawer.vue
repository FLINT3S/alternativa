<template>
  <n-button type="primary" secondary style="z-index: 2" @click="drawerActive = !drawerActive">debug</n-button>

  <span class="ml-10">{{ buildMode }}</span>

  <n-drawer v-model:show="drawerActive" height="490" placement="top" :style="'opacity:' + debugDrawerOpacity + '%'">
    <n-drawer-content title="AltDebug" closable>
      <n-form
          label-placement="left"
      >
        <n-space vertical>
          <n-space class="mb-10">
            <n-form-item label="Оверлей" :show-feedback="false">
              <n-switch v-model:value="isOverlayShown"/>
            </n-form-item>
            <n-divider vertical style="height: 100%;"/>
            <n-form-item label="Бэкдроп" :show-feedback="false">
              <n-switch v-model:value="isOverlayBackdropVisible"/>
            </n-form-item>
            <n-divider vertical style="height: 100%;"/>
            <n-form-item label="Транзишн бэкдропа" :show-feedback="false">
              <n-switch v-model:value="overlayBackdropTransition"/>
            </n-form-item>
            <n-divider vertical style="height: 100%;"/>
            <n-form-item label="HUD" :show-feedback="false">
              <n-switch v-model:value="isHUDShown"/>
            </n-form-item>
            <n-divider vertical style="height: 100%;"/>
            <n-form-item label="Транзишн HUD" :show-feedback="false">
              <n-switch v-model:value="HUDTransition"/>
            </n-form-item>
            <n-divider vertical style="height: 100%;"/>
            <n-form-item label="Непразрачность дебага" :show-feedback="false">
              <n-slider :max="100" :min="15" v-model:value="debugDrawerOpacity" style="width: 100px" :step="1"/>
            </n-form-item>
          </n-space>

          <n-form-item
              label="Роутер"
          >
            <n-cascader
                :on-update:value="onRouteChange"
                :options="routesOptions"
                :value="router.currentRoute.value.path"
                check-strategy="child"
                placeholder="Meaningless values"
            />
          </n-form-item>

          <n-form-item
              label="Клиентский экзекутор"
          >
            <n-input-group>
              <n-input
                  v-model:value="clientCodeExecute"
                  placeholder="Код"
                  rows="10"
                  type="textarea"
              ></n-input>
              <n-button style="height: auto" type="primary" @click="executeClientCode">
                Исполнить
              </n-button>
            </n-input-group>
          </n-form-item>

          <n-form-item
              label="Отправить событие"
          >
            <n-radio-group v-model:value="eventDispatchTo" name="eventto">
              <n-space>
                <n-radio
                    label="Клиенту"
                    value="client"
                />
                <n-radio
                    label="Серверу"
                    value="server"
                />
              </n-space>
            </n-radio-group>
            <n-input-group>
              <n-input
                  v-model:value="eventDispatchES"
                  placeholder="Событие"
              ></n-input>
              <n-input
                  v-model:value="eventDispatchData"
                  placeholder="Данные через запятую (без пробела)"
                  type="textarea"
              ></n-input>
              <n-button style="height: auto" type="primary" @click="sendEvent">
                Отправить
              </n-button>
            </n-input-group>
          </n-form-item>
        </n-space>
      </n-form>
    </n-drawer-content>
  </n-drawer>
</template>

<script lang="ts" setup>
import {NCascader, NDrawer, NDrawerContent, NInputGroup, NRadio, NRadioGroup, NSlider, NButton} from 'naive-ui'
import {computed, ref} from "vue";
import {useRouter} from "vue-router";
import {storeToRefs} from "pinia";
import {useRootStore} from "@/store";

const {
  isOverlayShown,
  altMpRoot,
  isOverlayBackdropVisible,
  overlayBackdropTransition,
  isHUDShown,
  HUDTransition
} = storeToRefs(useRootStore())
const drawerActive = ref(false)
const router = useRouter()
const clientCodeExecute = ref("")
const eventDispatchTo = ref("client")
const eventDispatchES = ref("")
const eventDispatchData = ref("")

const executeClientCode = () => {
  altMpRoot.value.triggerClient("Execute", clientCodeExecute.value)
}

const buildMode = computed(() => {
  return import.meta.env.MODE
})

const sendEvent = () => {
  if (eventDispatchTo.value === 'client') {
    altMpRoot.value.triggerClientRaw(eventDispatchES.value, eventDispatchData.value.split(','))
  } else {
    altMpRoot.value.triggerServerRaw(eventDispatchES.value, eventDispatchData.value.split(','))
  }
}

const getRoutesOptions = (routes: any[], parent?: any): any => {
  return routes.map(route => {
    const {path, children} = route
    const option = {label: path, value: path}

    const parentPath = parent?.label || ""

    if (parentPath) {
      option.label = `${path}`
      option.value = `${parentPath}/${path}`
    }

    if (children) {
      // @ts-ignore
      option.children = getRoutesOptions(children, option)
    }
    return option
  })
}

const routesOptions = computed(() => {
  return getRoutesOptions(router.options.routes as any[])
})

const onRouteChange = (value: string, option: any) => {
  console.log(value, option)
  router.push(value)
}

const debugDrawerOpacity = ref(100);
</script>
