import {createStore} from 'vuex'
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";

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
  modules: {}
})
