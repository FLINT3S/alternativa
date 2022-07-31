using System;
using System.Linq;
using Database.Models;
using GTANetworkAPI;

    namespace Database
    {
    public class Main : Script
        {
            [Command("register")]
            public void CmdRegisterAccount(Player player, string username, string password)
            {
                OnRegisterAccount(player, username, password);
                NAPI.Chat.SendChatMessageToPlayer(player, "~g~Registration successful!");
            }

            private void OnRegisterAccount(Player player, string username, string password)
            {
                var user = new User
                {
                    Name = player.Name,
                    Nickname = username,
                    RegisteredAt = DateTime.Now
                };

                using (var dbContext = new AlternativaContext())
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
        }
    }
    