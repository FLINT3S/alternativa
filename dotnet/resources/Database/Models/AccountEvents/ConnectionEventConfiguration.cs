using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.AccountEvents
{
    internal class ConnectionEventConfiguration : IEntityTypeConfiguration<ConnectionEvent>
    {
        public void Configure(EntityTypeBuilder<ConnectionEvent> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}