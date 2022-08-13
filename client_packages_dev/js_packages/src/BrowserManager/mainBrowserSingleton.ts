import {AltOverlayBrowser} from "./overlayBrowser";

export const altMainBrowser = new AltOverlayBrowser("http://package/web_packages/index.html", "Main")
// @ts-ignore
global.altMainBrowser = altMainBrowser
