using System;
using System.Linq;
using System.Linq.Expressions;
using Database;
using Database.Models;
using Database.Models.Bans;
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

        public static PermanentBan? GetBanByHwid(this Player player)
        {
            using var context = new AlternativaContext();
            return context.Bans.FirstOrDefault(
                b => b is PermanentBan && ((PermanentBan)b).HWID == player.Serial)
                as PermanentBan;
        }

        public static bool HasAccountInDb(this Player player)
        {
            using var context = new AlternativaContext();
            return context.Find<Account>(player.GetAccount()?.SocialClubId) != null;
        }

        /// <summary>
        /// <b>Использовать аккуратно!</b>
        /// После возвращения аккаунта контекст закрывается и работать с аккаунтом нужно через новый контекст,
        /// сохраняя его через db.Update(account)
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из базы данных</returns>
        public static Account? GetAccountFromDb(this Player player, params Expression<Func<Account, object>>[] includes)
        {
            using var db = new AlternativaContext();

            DbSet<Account>? query = db.Accounts;
            return includes
                .Aggregate(query.AsQueryable(), 
                        (current, include) => current.Include(include)
                    )
                .FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }
        
        /// <summary>
        /// Аккаунт получается из Data и существует только в рантайме
        /// Для получения аккаунта из базы данных нужно использовать <see cref="GetAccountFromDb"/>
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из <b>player.Data</b></returns>
        public static Account? GetAccount(this Player player) => 
            player.HasData(PlayerConstants.Account) ? 
                player.GetData<Account>(PlayerConstants.Account) : null;

        public static void SetAccount(this Player player, Account account) => 
            player.SetData(PlayerConstants.Account, account);

        public static Character? GetActiveCharacter(this Player player) => 
            player.GetAccount()!.ActiveCharacter;
    }
}