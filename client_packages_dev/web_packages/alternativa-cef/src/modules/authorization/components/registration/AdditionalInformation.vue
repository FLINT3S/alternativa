<template>
  <div class="additional-info">
    <h4>Прочая информация</h4>

    <alt-input
        class="mt-2"
        v-model="registrationData.email"
        :validation="v$.registrationData.email"
        show-validation-tooltip
        :debounce="500"
        :caption="emailCaption"
        :input-state="emailCaption ? 'invalid' : 'default'"
        placeholder="Электронная почта"
    />
    <div class="input-caption text-start">Почта нужна для восстановления доступа к аккаунту, обещаем не слать лишний спам!</div>

    <alt-button :disabled="v$.registrationData.email.$invalid || isEmailTaken" class="mt-3" stretched
                @click="nextStep">
      Дальше
    </alt-button>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import AltInput from "@/components/core/AltInput";
import {mapGetters} from "vuex";
import useVuelidate from "@vuelidate/core";
import {RegistrationDTO} from "@/modules/authorization/data/RegistrationDTO";
import AltButton from "@/components/core/AltButton";
import {altMpAuth} from "@/modules/authorization/data/altMpAuth";

export default defineComponent({
  name: "AdditionalInformation",
  components: {AltButton, AltInput},
  data() {
    return {
      isEmailTaken: false
    }
  },
  setup() {
    return {v$: useVuelidate()}
  },
  validations() {
    return {
      registrationData: {
        ...RegistrationDTO.validators
      }
    }
  },
  computed: {
    ...mapGetters([
      "registrationData"
    ]),
    emailCaption() {
      return this.isEmailTaken ? "Эта почта уже используется!" : ""
    }
  },
  watch: {
    "registrationData.email"() {
      if (this.v$.registrationData.email.$invalid) {
        this.isEmailTaken = false
        return
      }

      altMpAuth.triggerServer("CheckEmail", this.registrationData.email)
    }
  },
  methods: {
    nextStep() {
      this.$emit("nextStep");
    },
    onIsEmailTaken(isTaken) {
      this.isEmailTaken = isTaken;
    }
  },
  mounted() {
    altMpAuth.onServer("IsEmailTaken", this.onIsEmailTaken)
  }
})
</script>

<style scoped lang="scss">
</style>
