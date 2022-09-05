import {InfoHudData} from "@/modules/debug-hud/InfoHudData";
import {Vector3} from "@/data/Vector3";

export const gameInfoStore = {
  state: () => ({
    gameInfo: new InfoHudData(),
    showDebugHud: true
  }),
  getters: {
    commonGameInfo: (state: any): InfoHudData => state.gameInfo,
    showDebugHud: (state: any): boolean => state.showDebugHud
  },
  mutations: {
    setDebugHudVisibility(state: any, value: boolean) {
      state.showDebugHud = value;
    }
  },
  actions: {
    setDebugHudVisibility({commit}: any, value: boolean) {
      commit('setDebugHudVisibility', value);
    }
  }
}
