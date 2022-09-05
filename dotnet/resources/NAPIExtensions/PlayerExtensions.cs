using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Models;
using Database.Models.Bans;
using GTANetworkAPI;
using GTANetworkMethods;
using Microsoft.EntityFrameworkCore;
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
            using var context = new AltContext();
            return context.Bans.OfType<PermanentBan>().FirstOrDefault(b => b.HWID == player.Serial);
        }

        public static bool HasAccountInDb(this Player player) => Account.IsSocialClubIdTaken(player.SocialClubId);

        /// <param name="player">Объект игрока</param>
        /// <returns>Account из базы данных</returns>
        public static Account? GetAccountFromDb(this Player player)
        {
            using var context = new AltContext();
            return context
                .Accounts
                .Include(account => account.Characters)
                .Include(account => account.TemporaryBans)
                .Include(account => account.PermanentBan)
                .FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }

        /// <summary>
        ///     Аккаунт получается из Data и существует только в рантайме
        ///     Для получения аккаунта из базы данных нужно использовать <see cref="GetAccountFromDb" />
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из <b>player.Data</b></returns>
        public static Character? GetCharacter(this Player player) =>
            player.HasData(PlayerConstants.Character) ? player.GetData<Character>(PlayerConstants.Character) : null;

        public static void SetCharacter(this Player player, Character character) =>
            player.SetData(PlayerConstants.Character, character);

        public static void RemoveCharacter(this Player player) =>
            player.ResetData(PlayerConstants.Character);

        public static IEnumerable<Character> GetActiveCharacters(this Pools pools) =>
            pools.GetAllPlayers().Select(a => a.GetCharacter()).Where(c => c != null)!;
    }
}