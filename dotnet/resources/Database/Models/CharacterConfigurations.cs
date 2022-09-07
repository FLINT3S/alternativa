using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models
{
    internal class CharacterConfigurations : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StaticId).ValueGeneratedOnAdd();
            builder.Property("TimeToReborn");
            builder
                .HasOne(c => c.Appearance)
                .WithOne(a => a.Owner)
                .HasForeignKey<CharacterAppearance>(a => a.OwnderId);
            builder
                .HasOne(c => c.Finances)
                .WithOne(a => a.Owner)
                .HasForeignKey<CharacterFinances>(a => a.OwnerId);
            builder
                .HasOne(c => c.SpawnData)
                .WithOne(a => a.Owner)
                .HasForeignKey<CharacterSpawnData>(a => a.OwnerId);
        }
    }
}