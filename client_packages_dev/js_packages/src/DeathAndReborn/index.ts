import {ModuleBrowser} from "../BrowserManager/altBrowser";
import {logger} from "../utils/logger";

let DRBrowser = new ModuleBrowser("DeathAndReborn", "/death-and-reborn")

mp.events.add("SERVER:CLIENT:DeathAndReborn:Death", (secondsToReborn: number, deathReason: string) => {
  mp.game.gameplay.setFadeOutAfterDeath(false);

  DRBrowser.setAsActive()
  DRBrowser.execClient("Death", secondsToReborn, deathReason)
  DRBrowser.browser.openOverlay(true)
  DRBrowser.browser.settings.canCloseOverlay = false

  mp.game.audio.playSound(-1, "ScreenFlash", "WastedSounds", true, 0, true)
  mp.game.graphics.startScreenEffect("DeathFailMPIn", secondsToReborn * 1000, false)
})

mp.events.add("SERVER:CLIENT:DeathAndReborn:Reborn", () => {
  mp.game.graphics.stopScreenEffect("DeathFailMPIn")

  DRBrowser.execClient("Reborn")
  DRBrowser.browser.settings.canCloseOverlay = true
  DRBrowser.browser.closeOverlay()
})
