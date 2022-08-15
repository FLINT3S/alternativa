using System.Linq;
using Database;
using Database.Models;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace NAPIExtensions
{
    public static class PlayerExtensions
    {
        public static string GetPlayerDataString(this Player player)
        {
            string response = "New player connected:\n";
            response += $"name: {player.Name}\n";
            response += $"socialClubId: {player.SocialClubId}\n";
            response += $"IP: {player.Address}";
            response += $"HWID: {player.Serial}\n";
            response += $"socialClubName: {player.SocialClubName}\n";
            response += "===========================================================";
            return response;
        }
        
        public static Account GetAccount(this Player player)
        {
            using var db = new AlternativaContext();

            return db.Accounts.FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }
        
        public static Account GetAccountWithActiveCharacter(this Player player)
        {
            using var db = new AlternativaContext();

            return db.Accounts.Include(a => a.ActiveCharacter).FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }
        
        public static Account GetAccountWithCharactersList(this Player player)
        {
            using var db = new AlternativaContext();

            return db.Accounts.Include(a => a.Characters).FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }

        public static Character GetActiveCharacter(this Player player)
        {
            return player.GetAccountWithActiveCharacter().ActiveCharacter;
        }
    }
}