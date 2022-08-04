<template>
  <main class="d-flex">
    AdminPanel
    <router-view/>
  </main>
</template>

<script>
import { defineComponent } from 'vue';
import {openOverlayMixin} from "@/mixins/openOverlayMixin";

export default defineComponent({
  name: 'AdminPanel',
  mixins: [openOverlayMixin],
  data() {
    return {
      overlayTitle: "Admin Panel",
      isOpened: false
    };
  },
});
</script>

<style lang="scss">

</style>
