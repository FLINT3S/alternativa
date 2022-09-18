import {InfoHudData} from "@/modules/debug-hud/InfoHudData";

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
