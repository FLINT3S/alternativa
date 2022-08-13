<template>
  <alt-overlay :is-overlay-open="isOverlayOpen">
    <section class="d-flex admin-panel-box">
      <h3>Alternativa AdminPanel</h3>
      <br>
      <button @click="randomDamage">Рандомный урон</button>
      <div class="d-flex">
        <input type="text" v-model="executeServerEvent">
        <button @click="sendServerEvent">Отправить событие на сервер</button>
      </div>
      <router-view/>
    </section>
  </alt-overlay>
</template>

<script>
import {defineComponent} from 'vue';
import {openOverlayMixin} from "@/mixins/openOverlayMixin";
import AltOverlay from "@/components/AltOverlay";
import {altLog} from "@/connect/logs/altLogger";

export default defineComponent({
  name: 'AdminPanel',
  components: {AltOverlay},
  mixins: [openOverlayMixin],
  data() {
    return {
      overlayTitle: "Admin Panel",
      executeServerEvent: "CEF:SERVER:AdminPanel:randomDamage"
    };
  },
  methods: {
    randomDamage() {
      this.$altMp.triggerServer("randomDamage");
    },
    sendServerEvent() {
      this.$altMp.triggerServerRawEvent(this.executeServerEvent);
    }
  },
  created() {
    this.$altMp.onServer("OnTest", () => {
      altLog.warning("OnTest");
    });
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
