import {ModuleBrowser} from "../BrowserManager/altBrowser";

let DRBrowser = new ModuleBrowser("DeathAndReborn", "/death-and-reborn")

mp.events.add("SERVER:CLIENT:DeathAndReborn:Death", (secondsToReborn: number) => {
  mp.game.gameplay.setFadeOutAfterDeath(false);

  DRBrowser.setAsActive()
  DRBrowser.execClient("Death", secondsToReborn)
  DRBrowser.browser.openOverlay(true)

  mp.game.audio.playSound(-1, "ScreenFlash", "WastedSounds", true, 0, true)
  mp.game.graphics.startScreenEffect("DeathFailMPIn", 300_000, false)
})

mp.events.add("SERVER:CLIENT:DeathAndReborn:Reborn", () => {
  mp.game.graphics.stopScreenEffect("DeathFailMPIn")

  DRBrowser.execClient("Reborn")
  DRBrowser.browser.closeOverlay()
})
