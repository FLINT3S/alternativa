using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Models;
using Database.Models.Bans;
using GTANetworkMethods;
using Player = GTANetworkAPI.Player;

namespace NAPIExtensions
{
    public static class PlayerExtensions
    {
        public static string GetPlayerConnectedDataString(this Player player)
        {
            string response = "New player connected:\n";
            response += $"Name: {player.Name}\n";
            response += $"SocialClubId: {player.SocialClubId}\n";
            response += $"IP: {player.Address}";
            response += $"HWID: {player.Serial}\n";
            response += $"SocialClubName: {player.SocialClubName}\n";
            response += "===========================================================";
            return response;
        }

        public static string GetString(this Player player) => $"{player.SocialClubName}_[{player.SocialClubId}]";

        public static PermanentBan? GetBanByHwid(this Player player)
        {
            lock (AltContext.Locker)
            {
                return AltContext.Instance.Bans.FirstOrDefault(
                            b => b is PermanentBan && ((PermanentBan)b).HWID == player.Serial
                        )
                    as PermanentBan;
            }
        }

        public static bool HasAccountInDb(this Player player) => Account.IsSocialClubIdTaken(player.SocialClubId);

        /// <param name="player">Объект игрока</param>
        /// <returns>Account из базы данных</returns>
        public static Account? GetAccountFromDb(this Player player)
        {
            lock (AltContext.Locker)
            {
                return AltContext
                    .Instance
                    .Accounts
                    .FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
            }
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

        public static void RemoveAccount(this Player player) => 
            player.ResetData(PlayerConstants.Account);

        public static IEnumerable<Account> GetActiveAccounts(this Pools pools) =>
            pools.GetAllPlayers().Select(p => p.GetAccount()).Where(a => a != null)!;

        public static IEnumerable<Character> GetActiveCharacters(this Pools pools) =>
            pools.GetActiveAccounts().Select(a => a.ActiveCharacter).Where(c => c != null);
    }
}