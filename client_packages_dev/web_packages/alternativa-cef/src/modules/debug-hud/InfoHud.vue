<template>
  <div class="info-hud d-flex" v-if="showDebugHud">
    <div class="cell">
      <p class="me-1">FPS:</p>
      <p class="me-1">Position:</p>
      <p class="me-1">Velocity vector:</p>
      <p class="me-1">Velocity:</p>
      <p class="me-1">Heading:</p>
    </div>
    <div class="information cell">
      <p>{{ commonGameInfo.fps }}</p>
      <p>{{ commonGameInfo.position?.toString() }}</p>
      <p>{{ commonGameInfo.velocityVec?.toString() }}</p>
      <p>{{ commonGameInfo.speed }}</p>
      <p>{{ commonGameInfo.heading }}</p>
    </div>
  </div>
</template>

<script>
import {defineComponent} from "vue";
import {mapActions, mapGetters} from "vuex";
import {altMP} from "@/connect/events/altMP";
import {Vector3} from "@/data/Vector3";

export default defineComponent({
  name: "InfoHud",
  data() {
    return {
      altMpDebugHud: new altMP("DebugHud", "1")
    }
  },
  computed: {
    ...mapGetters(["commonGameInfo", "showDebugHud"])
  },
  methods: {
    ...mapActions(["setDebugHudVisibility"])
  },
  mounted() {
    this.altMpDebugHud.on("setDebugHudVisibility", (value) => {
      this.setDebugHudVisibility(value);
    });

    // altMp bypass to increase performance
    window.setGameInfo = (gameInfo) => {
      this.commonGameInfo.fps = gameInfo.fps;
      this.commonGameInfo.position = Vector3.fromVector3Mp(gameInfo.position);
      this.commonGameInfo.heading = gameInfo.heading;
      this.commonGameInfo.velocityVec = Vector3.fromVector3Mp(gameInfo.velocityVec);
    }
  }
})
</script>

<style scoped>
.info-hud {
  position: absolute;
  bottom: 20px;
  right: 20px;
}

.information {
  width: 250px;
}

.cell p {
  height: 20px;
  font-size: 14px;
}
</style>
