import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {AuthorizationEvents} from "../Authorization/AuthorizationEvents";

const characterManagerBrowser = new ModuleBrowser("CharacterManager", "/character-manager/select-character")

mp.events.add(AuthorizationEvents.GO_TO_CHARACTER_MANAGER, () => {
  characterManagerBrowser.setAsActive()
})
