<template>
  <main class="d-flex">
    AdminPanel123
    <span class="material-icons-round" @click="check">account_circle</span>
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
  methods: {
    check() {
      window.altMP.call("CLIENT:CEF:AltAdminPanel:onOpenOverlay", {a: 213})
    }
  }
});
</script>

<style lang="scss">

</style>
