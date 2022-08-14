using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.SocialClubId);
            builder.HasMany(a => a.Characters).WithOne(c => c.Account);
            builder.HasMany(a => a.Connections).WithOne();
        }
    }
}