<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <section class="d-flex admin-panel-box">
      <h3>Alternativa AdminPanel</h3>
      <router-view/>
    </section>
  </alt-overlay>
</template>

<script>
import {defineComponent} from 'vue';
import {openOverlayMixin} from "@/mixins/openOverlayMixin";
import AltOverlay from "@/components/AltOverlay";

export default defineComponent({
  name: 'AdminPanel',
  components: {AltOverlay},
  mixins: [openOverlayMixin],
  data() {
    return {
      overlayTitle: "Admin Panel",
    };
  },
  methods: {
  }
});
</script>

<style lang="scss">
.admin-panel-box {
  padding: 32px 20px;
  background-color: var(--color-background-primary);
  color: white;
}
</style>
