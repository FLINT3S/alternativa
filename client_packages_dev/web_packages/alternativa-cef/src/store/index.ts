import {createStore} from 'vuex'
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";
import {gameInfoStore} from "@/store/modules/gameInfoStore";

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
    gameInfo: gameInfoStore
  }
})
