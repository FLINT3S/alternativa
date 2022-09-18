<template>
  <div class="parents-editor content-scroll">
    <div class="selected-parents d-flex justify-content-center">
      <div class="parent-avatar text-center d-flex flex-column align-items-center mx-2">
        <img :src="`parents/male_${characterData.parents.father.name}.png`" class="avatar-img large">
        <span class="parent-name">{{ characterData.parents.father.name }}</span>
      </div>

      <div class="and my-auto">
        &
      </div>

      <div class="parent-avatar text-center d-flex flex-column align-items-center mx-2">
        <img :src="`parents/female_${characterData.parents.mother.name}.png`" class="avatar-img large">
        <span class="parent-name">{{ characterData.parents.mother.name }}</span>
      </div>
    </div>

    <hr>

    <h5 class="mt-3">Настройки</h5>
    <alt-slider
        v-model="characterData.parents.similarity"
        :debounce="100"
        :interval="0.02"
        :marks="{'0': 'Отец', '1': 'Мать'}"
        :max="1"
        :min="0"
        :process="false"
        :tooltip="'none'"
    />
    <div class="tiny-text mt-4">Степень похожести внешности на родителей</div>
    <alt-slider
        v-model="characterData.parents.skinSimilarity"
        :debounce="100"
        :interval="0.02"
        :marks="{'0': 'Отец', '1': 'Мать'}"
        :max="1"
        :min="0"
        :process="false"
        :tooltip="'none'"
        class="mt-3"
    />
    <div class="tiny-text mt-4">Похожесть тона кожи на родителей</div>

    <alt-button size="xs" stretched class="mt-2" @click="characterData.randomizeParents()">
      Случайные родители
    </alt-button>

    <hr>

    <div class="choose-mother mt-2">
      <div class="text-center mb-2">
        <h6>Мать</h6>
      </div>
      <alt-horizontal-scroll>
        <div v-for="mother in mothers"
             :key="mother.id" class="parent-avatar text-center d-flex flex-column align-items-center me-2"
             @click="onSelectMother(mother)"
        >
          <img :class="{'inactive': characterData.parents.mother.id !== mother.id}"
               :src="`parents/female_${mother.name}.png`"
               class="avatar-img">
          <span class="parent-name">{{ mother.name }}</span>
        </div>
      </alt-horizontal-scroll>
    </div>

    <div class="choose-father mt-2">
      <div class="text-center mb-2">
        <h6>Отец</h6>
      </div>
      <alt-horizontal-scroll>
        <div v-for="father in fathers"
             :key="father.id" class="parent-avatar text-center d-flex flex-column align-items-center me-2"
             @click="onSelectFather(father)"
        >
          <img :class="{'inactive': characterData.parents.father.id !== father.id}"
               :src="`parents/male_${father.name}.png`"
               class="avatar-img">
          <span class="parent-name">{{ father.name }}</span>
        </div>
      </alt-horizontal-scroll>
    </div>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import {CharacterData} from "@/modules/character-manager/data/CharacterData";
import {fathers, mothers} from "@/modules/character-manager/data/creatorData";
import AltHorizontalScroll from "@/components/core/AltHorizontalScroll";
import AltSlider from "@/components/core/AltSlider";
import AltButton from "@/components/core/AltButton";

export default defineComponent({
  name: "ParentsEditor",
  components: {AltButton, AltSlider, AltHorizontalScroll},
  props: {
    characterData: {
      type: CharacterData,
      required: true
    }
  },
  data() {
    return {
      fathers: fathers,
      mothers: mothers,
      updateDebounceTimer: null
    }
  },
  watch: {
    "characterData.parents": {
      handler: function () {
        clearTimeout(this.updateDebounceTimer);
        this.updateDebounceTimer = setTimeout(() => {
          this.characterData.updateParentsData()
        }, 100);
      },
      deep: true
    }
  },
  methods: {
    onSelectMother(mother) {
      this.characterData.parents.mother = mother
    },
    onSelectFather(father) {
      this.characterData.parents.father = father
    }
  }
})
</script>

<style lang="scss" scoped>
.selected-parents {
  .and {
    font-size: 32px;
    font-weight: 300;
    color: var(--accent-primary);
  }
}

.parent-avatar {
  .avatar-img {
    width: 70px;
    height: 70px;
    border-radius: 1000px;
    margin-bottom: 4px;
    opacity: 1;
    filter: grayscale(0);
    transition: all .3s ease;

    &.large {
      width: 85px;
      height: 85px;
    }

    &.inactive {
      opacity: 0.9;
      filter: grayscale(1);
    }

    &.inactive:hover {
      opacity: 0.9;
      filter: grayscale(.2);
    }
  }

  .parent-name {
    font-size: 14px;
  }
}

.mothers-scroll {
  overflow-x: auto;
  padding-right: 12px;
}
</style>
