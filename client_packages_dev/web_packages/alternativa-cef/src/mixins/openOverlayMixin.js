export const openOverlayMixin = {
    data() {
        return {
            isOverlayOpen: false,
        };
    },
    methods: {
        onOpenOverlay: function () {
            this.isOverlayOpen = true;
        },
        onCloseOverlay: function () {
            this.isOverlayOpen = false;
        },
        onToggleOverlay: function () {
            this.isOverlayOpen = !this.isOverlayOpen;
        }
    },
    created() {
        this.$altMp.on("onOpenOverlay", this.onOpenOverlay);
        this.$altMp.on("onCloseOverlay", this.onCloseOverlay);
        this.$altMp.on("onToggleOverlay", this.onToggleOverlay);
    }
}
