import {altMP} from "@/connect/events/altMP";
import {App} from "vue";
import {altRPC} from "@/connect/events/altRPC";

export const connectRage = {
  install(app: App, options: {moduleName: string, moduleVersion: string}) {
    let altEnv: string;
    try {
      // @ts-ignore
      const _mp = mp
      altEnv = "mp"
    } catch (e) {
      altEnv = "node"
    }
    app.config.globalProperties.$altEnv = altEnv

    if (altEnv === "mp") {
      app.config.globalProperties.$moduleName = options.moduleName
      app.config.globalProperties.$moduleVersion = options.moduleVersion
      app.config.globalProperties.$altMp = new altMP(options.moduleName, options.moduleVersion)
      app.config.globalProperties.$altRPC = new altRPC(options.moduleName, options.moduleVersion)
    }
  }
}
