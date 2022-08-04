<template>
  <main class="d-flex">
    <nav class="d-flex flex-column">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </nav>
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
