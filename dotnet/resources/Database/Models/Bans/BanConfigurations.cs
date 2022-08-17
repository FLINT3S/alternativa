using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Bans
{
    public class BanConfigurations : 
        IEntityTypeConfiguration<AbstractBan>, 
        IEntityTypeConfiguration<PermanentBan>,
        IEntityTypeConfiguration<TemporaryBan>
    {
        public void Configure(EntityTypeBuilder<AbstractBan> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasDiscriminator();
        }
        
        public void Configure(EntityTypeBuilder<PermanentBan> builder)
        {
        }
        
        public void Configure(EntityTypeBuilder<TemporaryBan> builder)
        {
        }
    }
}