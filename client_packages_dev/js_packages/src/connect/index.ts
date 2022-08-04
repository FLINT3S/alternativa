mp.events.add("CEF:CLIENT:Global:Echo", (...data: any) => {
  console.log("CEF:CLIENT:Global:Echo", ...data)
  mp.gui.chat.push("CEF:CLIENT:Global:Echo");
})


mp.events.add("playerJoin", (player) => {
  mp.gui.chat.push(`${player.name} has joined the server!`);
});


mp.events.add("playerCommand", (command) => {
  mp.gui.chat.push(`${command}`);
})
