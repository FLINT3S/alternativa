using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models
{
    public class CharacterAppearanceConfiguration : IEntityTypeConfiguration<CharacterAppearance>
    {
        public void Configure(EntityTypeBuilder<CharacterAppearance> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}