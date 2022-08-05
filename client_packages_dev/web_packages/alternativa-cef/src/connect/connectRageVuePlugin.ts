import {altMP} from "@/connect/events/altMP";
import {App} from "vue";
import {altLog} from "@/connect/logs/altLogger";
import {altRPC} from "@/connect/events/rpc/altRPC";

export const connectRage = {
  install(app: App, options: {moduleName: string, moduleVersion: string}) {
    let altEnv: string;
    // @ts-ignore
    if (mp?.isFake) {
      altEnv = "node"
    } else {
      altEnv = "mp"
    }
    app.config.globalProperties.$altEnv = altEnv

    if (altEnv === "mp") {
      app.config.globalProperties.$moduleName = options.moduleName
      app.config.globalProperties.$moduleVersion = options.moduleVersion
      app.config.globalProperties.$altMp = new altMP(options.moduleName, options.moduleVersion)
      app.config.globalProperties.$altRPC = new altRPC(options.moduleName, options.moduleVersion)
      // @ts-ignore
      window.altMP = app.config.globalProperties.$altMp
    }

    // @ts-ignore
    window.altLog = altLog
    altLog.warning(`${options.moduleName} [${options.moduleVersion}] loaded in ${altEnv} environment`)
  }
}
