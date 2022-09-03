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
      />
      <alt-input
          v-model="characterData.surname"
          class="mt-1"
          placeholder="Фамилия"
      />
      <alt-input
          v-model="characterData.age"
          class="mt-1"
          placeholder="Возраст"
      />
    </alt-card>
  </div>
</template>

<script>
import AltInput from "@/components/core/AltInput";
import AltCard from "@/components/core/AltCard";
import GenderButton from "@/modules/character-manager/components/GenderButton";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import {altMpCM} from "@/modules/character-manager/data/altMpCM";

export default {
  name: "CreatorCommonInfo",
  components: {GenderButton, AltCard, AltInput},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  methods: {
    onSetGender(gender) {
      altMpCM.triggerServerWithAnswerPending("ChangeGender", "OnGenderChanged", gender).then(() => {
        this.sendParentsChanges()
        this.characterData.gender = gender
      })
    },
    sendParentsChanges() {
      altMpCM.triggerClient("UpdateParents", JSON.stringify(this.characterData.parents))
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
