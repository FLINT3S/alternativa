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
        

        /// <summary>
        /// <b>Использовать аккуратно!</b>
        /// После возвращения аккаунта контекст закрывается и работать с аккаунтом нужно через новый контекст,
        /// сохраняя его через db.Update(account)
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из базы данных</returns>
        public static Account GetAccountFromDb(this Player player)
        {
            using var db = new AlternativaContext();

            return db.Accounts.FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }
        
        /// <summary>
        /// Аккаунт получается из Data и существует только в рантайме
        /// Для получения аккаунта из базы данных нужно использовать <see cref="GetAccountFromDb"/>
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из <b>player.Data</b></returns>
        public static Account GetAccount(this Player player)
        {
            if (player.HasData("account"))
            {
                // TODO: Вынести строку ключа даты в константу (отдельный класс?)
                return player.GetData<Account>("account");
            }

            return null;
        }
        
        public static void SetAccount(this Player player, Account account)
        {
            // TODO: Вынести строку ключа даты в константу (отдельный класс?)
            player.SetData("account", account);
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