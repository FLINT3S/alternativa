using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Economics.Cash
{
    public class CashTransactionConfiguration : IEntityTypeConfiguration<CashTransaction>
    {

        public void Configure(EntityTypeBuilder<CashTransaction> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}