using Database.Models.Bans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(account => account.Id);
            builder.Property("PasswordHash");
            builder.Property("PasswordSalt");
            builder.Property("Email");
            builder.Property(a => a.LastHwid);

            builder.HasMany(a => a.Characters)
                .WithOne(c => c.Account)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Connections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.TemporaryBans)
                .WithOne(b => b.GivenTo)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.PermanentBan)
                .WithOne(b => b.GivenTo)
                .HasForeignKey<PermanentBan>("AccountId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}