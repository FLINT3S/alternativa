using System;
using System.Linq;
using Database.Models;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public partial class AltContext
    {
        public static bool HasAccount(Player player) => Account.IsSocialClubIdTaken(player.SocialClubId);
        
        public static Account GetAccount(Player player)
        {
            using var context = new AltContext();
            return context
                .Accounts
                .Include(account => account.Characters)
                .Include(account => account.TemporaryBans)
                .Include(account => account.PermanentBan)
                .FirstOrDefault(a => a.SocialClubId == player.SocialClubId);
        }

        public static Character GetCharacter(Player player, Guid guid)
        {
            using var context = new AltContext();
            return context
                .Accounts
                .Include(a => a.Characters)
                .ThenInclude(c => c.Appearance)
                .Include(a => a.Characters)
                .ThenInclude(c => c.Finances)
                .Include(a => a.Characters)
                .ThenInclude(c => c.SpawnData)
                .First(a => a.SocialClubId == player.SocialClubId)
                .Characters
                .FirstOrDefault(c => c.Id == guid);
        }
    }
}