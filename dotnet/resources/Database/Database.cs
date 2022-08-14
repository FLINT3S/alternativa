using System;
using System.Linq;
using Database.Models;
using GTANetworkAPI;

    namespace Database
    {
    public class Main : Script
        {
            [Command("register")]
            public void CmdRegisterAccount(Player player, string username, string password, string email)
            {
                OnRegisterAccount(player, username, password, email);
                NAPI.Chat.SendChatMessageToPlayer(player, "~g~Registration successful");
                NAPI.Util.ConsoleOutput("New user registered: " + player.Name + " with this nickname: " + username);
            }

            private static void OnRegisterAccount(Player player, string username, string password, string email)
            {
                var account = new Account(player.SocialClubId, username, password, email);

                using var dbContext = new AlternativaContext();

                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
            }
        }
    }
    