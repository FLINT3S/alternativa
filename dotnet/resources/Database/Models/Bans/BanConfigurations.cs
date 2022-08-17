using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Bans
{
    public class BanConfigurations : IEntityTypeConfiguration<AbstractBan>
    {
        public void Configure(EntityTypeBuilder<AbstractBan> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasDiscriminator();
        }
    }
}