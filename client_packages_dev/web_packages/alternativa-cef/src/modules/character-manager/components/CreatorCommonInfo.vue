<template>
  <div class="common-character-info">
    <alt-card>
      <h5>Основная информация</h5>

      <div class="d-flex justify-content-center mt-3 mb-3">
        <gender-button
            :active="characterData.gender === 0"
            @click="onSetGender(0)"
            icon="male"
        >
          мужчина
        </gender-button>
        <gender-button
            :active="characterData.gender === 1"
            @click="onSetGender(1)"
            icon="female"
        >
          женщина
        </gender-button>
      </div>

      <h6>Личные данные</h6>

      <alt-input
          v-model="characterData.name"
          placeholder="Имя"
          :pattern="/^[A-Za-z]*$/"
          show-validation-tooltip
          :validation="v$.characterData.name"
          :process-value="(v) => v[0].toUpperCase() + v.slice(1, v.length).toLowerCase()"
      />
      <alt-input
          v-model="characterData.surname"
          class="mt-1"
          placeholder="Фамилия"
          :pattern="/^[A-Za-z]*$/"
          show-validation-tooltip
          :validation="v$.characterData.surname"
          :process-value="(v) => v[0].toUpperCase() + v.slice(1, v.length).toLowerCase()"
      />
      <alt-input
          v-model="characterData.age"
          class="mt-1"
          placeholder="Возраст"
          :pattern="/^[0-9]*$/"
          type="number"
          show-validation-tooltip
          :validation="v$.characterData.age"
      />
      <alt-button stretched class="mt-3" :disabled="v$.characterData.$invalid" @click="onCharacterSubmit">
        Создать персонажа
      </alt-button>
    </alt-card>
  </div>
</template>

<script>
import AltInput from "@/components/core/AltInput";
import AltCard from "@/components/core/AltCard";
import GenderButton from "@/modules/character-manager/components/GenderButton";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";
import useVuelidate from "@vuelidate/core";
import AltButton from "@/components/core/AltButton";

export default {
  name: "CreatorCommonInfo",
  components: {AltButton, GenderButton, AltCard, AltInput},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  setup() {
    return {v$: useVuelidate()}
  },
  validations() {
    return {
      characterData: {
        ...CharacterData.validators
      }
    }
  },
  methods: {
    onSetGender(gender) {
      altMpCM.triggerServerWithAnswerPending("ChangeGender", gender).then(() => {
        this.characterData.updateParentsData()
        this.characterData.updateFaceFeaturesData()
        this.characterData.gender = gender
      })
    },
    onCharacterSubmit() {
      altMpCM.triggerClient("CharacterCreatedSubmit", this.characterData.commonInfo)
    }
  }
}
</script>

<style lang="scss" scoped>
.common-character-info {
  position: absolute;
  left: 50px;
  margin-top: auto;
  width: 350px;
  top: 25%;
  height: auto;
  text-align: center;
}
</style>
