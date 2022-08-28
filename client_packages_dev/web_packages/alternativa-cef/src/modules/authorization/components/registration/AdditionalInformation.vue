<template>
  <div class="additional-info">
    <h4>Прочая информация</h4>

    <alt-input
        class="mt-2"
        v-model="registrationData.email"
        :validation="v$.registrationData.email"
        show-validation-tooltip
        placeholder="Электронная почта"
    />
    <div class="input-caption text-start">Почта нужна для восстановления доступа к аккаунту, обещаем не слать лишний спам!</div>

    <alt-button :disabled="v$.registrationData.email.$invalid" class="mt-3" stretched
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

export default defineComponent({
  name: "AdditionalInformation",
  components: {AltButton, AltInput},
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
  },
  methods: {
    nextStep() {
      this.$emit("nextStep");
    }
  }
})
</script>

<style scoped lang="scss">
.additional-info {
  height: 200px;
}
</style>
