// import {altMp} from "@/utils/altMp";

export const openOverlayMixin = {
  data() {
    return {
      overlayTitle: "DefaultOverlayTitle",
    };
  },
  methods: {
    onOpenOverlay: function () {
      console.log("Open overlay")
    }
  },
  created() {
    this.$altMp.on("openOverlay", this.onOpenOverlay);
    console.log("openOverlayMixin created");
  }
}
