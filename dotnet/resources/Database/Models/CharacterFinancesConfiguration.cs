using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models
{
    public class CharacterFinancesConfiguration : IEntityTypeConfiguration<CharacterFinances>
    {
        public void Configure(EntityTypeBuilder<CharacterFinances> builder)
        {
            builder.HasKey(f => f.Id);
            builder
                .HasMany(f => f.BankAccounts)
                .WithOne("OwnerFinances");
        }
    }
}