mp.events.add("SERVER:CLIENT:DeathAndReborn:Death", () => {
    mp.game.graphics.startScreenEffect("DeathFailMPIn", 300_000, false)
})

mp.events.add("SERVER:CLIENT:DeathAndReborn:Reborn", () => {
    mp.game.graphics.stopScreenEffect("DeathFailMPIn")
})
