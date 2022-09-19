import {defineStore} from "pinia";
import {altMP} from "@/connect/events/altMP";
import type {Ref} from "vue";
import {ref} from "vue";
import {LoginDTO} from "@/module/authorization/data/LoginDTO";
import {RegistrationDTO} from "@/module/authorization/data/RegistrationDTO";

export const useAuthStore = defineStore('auth', () => {
  const altMpAuth = ref(new altMP("Authorization", "1"))
  const loginData: Ref<LoginDTO> = ref(new LoginDTO())
  const authAttempts: Ref<number> = ref(0)

  const registrationData: Ref<RegistrationDTO> = ref(new RegistrationDTO())

  return {
    loginData,
    altMpAuth,
    authAttempts,
    registrationData
  }
})
