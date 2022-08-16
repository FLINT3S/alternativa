using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.SocialClubId);
            builder.Property("PasswordHash");
            builder.Property("PasswordSalt");
            builder.HasMany(a => a.Characters).WithOne(c => c.Account).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.ActiveCharacter);
            builder.HasMany(a => a.Connections).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}