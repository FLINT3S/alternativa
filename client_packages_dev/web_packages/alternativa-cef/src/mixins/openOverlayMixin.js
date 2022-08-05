// import {altMp} from "@/utils/altMp";

export const openOverlayMixin = {
  data() {
    return {
      overlayTitle: "DefaultOverlayTitle",
    };
  },
  methods: {
    onOpenOverlay: function (data) {
      console.log("Open overlay", data)
    }
  },
  created() {
    this.$altMp.on("onOpenOverlay", this.onOpenOverlay);
    console.log("openOverlayMixin created");
  }
}
