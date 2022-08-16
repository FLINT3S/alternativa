using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.SocialClubId);
            builder.HasMany(a => a.Characters).WithOne(c => c.Account);
            builder.HasOne(a => a.ActiveCharacter);
            builder.HasMany(a => a.Connections).WithOne();
        }
    }
}