using System;
using System.Linq;
using Database.Models;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public partial class AltContext
    {
        public static Character GetCharacter(Player player, Guid guid)
        {
            using var context = new AltContext();
            return context
                .Accounts
                .Include(a => a.Characters)
                .ThenInclude(c => c.Appearance)
                .First(a => a.SocialClubId == player.SocialClubId)
                .Characters
                .FirstOrDefault(c => c.Id == guid);
        }
    }
}