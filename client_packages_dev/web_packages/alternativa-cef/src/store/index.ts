import {createStore} from 'vuex'
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";
import {gameInfoStore} from "@/store/modules/gameInfoStore";
import {characterManagerStore} from "@/store/modules/characterManagerStore";

export default createStore({
  state: {
    registrationData: new RegistrationDTO()
  },
  getters: {
    registrationData: state => state.registrationData
  },
  mutations: {

  },
  actions: {

  },
  modules: {
    gameInfo: gameInfoStore,
    characterManager: characterManagerStore
  }
})
