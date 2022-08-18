import {AuthorizationEvents} from "../Authorization/AuthorizationEvents";
import {AltOverlayBrowser} from "../BrowserManager/altBrowser";

let characterManagerBrowser = new AltOverlayBrowser("http://package/web_packages/character-manager.html", "CharacterManager", {toggleCursor: true});

mp.events.add(AuthorizationEvents.GO_TO_CHARACTER_MANAGER, () => {
  characterManagerBrowser.openOverlay()
})
