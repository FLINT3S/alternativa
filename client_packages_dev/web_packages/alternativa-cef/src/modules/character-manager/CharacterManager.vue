<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <router-view/>
  </alt-overlay>
</template>

<script>
import {defineComponent} from 'vue';
import {openOverlayMixin} from "@/mixins/openOverlayMixin";
import AltOverlay from "@/components/AltOverlay";

export default defineComponent({
  name: 'character-manager',
  components: {AltOverlay},
  mixins: [openOverlayMixin],
  data() {
    return {};
  },
});
</script>

<style lang="scss">

</style>
