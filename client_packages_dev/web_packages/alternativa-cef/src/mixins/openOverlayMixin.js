export const openOverlayMixin = {
    data() {
        return {
            isOverlayOpen: process.env.NODE_ENV === 'development',
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
    mounted() {
        this.altMp.on("onOpenOverlay", this.onOpenOverlay);
        this.altMp.on("onCloseOverlay", this.onCloseOverlay);
        this.altMp.on("onToggleOverlay", this.onToggleOverlay);
    }
}
