using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.AccountEvents
{
    internal class EventConfigurations : IEntityTypeConfiguration<AccountEvent>,
        IEntityTypeConfiguration<ConnectionEvent>
    {
        public void Configure(EntityTypeBuilder<AccountEvent> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasDiscriminator();
        }

        public void Configure(EntityTypeBuilder<ConnectionEvent> builder)
        {
        }
    }
}