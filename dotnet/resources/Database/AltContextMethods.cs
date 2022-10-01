using System;
using System.Linq;
using Database.Models;
using Database.Models.Rooms;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public partial class AltContext
    {
        public static bool IsRegisteredPlayer(Player player) => Account.IsSocialClubIdTaken(player.SocialClubId);
        
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
                .Include(a => a.Characters)
                .ThenInclude(c => c.Account)
                .ThenInclude(a => a.Connections)
                .First(a => a.SocialClubId == player.SocialClubId)
                .Characters
                .FirstOrDefault(c => c.Id == guid);
        }

        public static Character GetCharacter(long staticId)
        {
            using var context = new AltContext();
            return context
                .Characters
                .Include(c => c.Account)
                .ThenInclude(a => a.Connections)
                .Include(c => c.Account)
                .ThenInclude(a => a.Characters)
                .Include(c => c.Appearance)
                .Include(c => c.Finances)
                .Include(c => c.SpawnData)
                .FirstOrDefault(c => c.StaticId == staticId);
        }

        public static AbstractRoom GetRoom(Guid guid)
        {
            using var context = new AltContext();
            return context.Rooms.Include(r => r.Exit).First(r => r.Id == guid);
        }
    }
}