using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Economics.Banks.Transactions
{
    public class TransactionConfiguration : 
        IEntityTypeConfiguration<AbstractBankTransaction>,
        IEntityTypeConfiguration<BetweenCharactersTransaction>,
        IEntityTypeConfiguration<DutyTransaction>,
        IEntityTypeConfiguration<PurchaseTransaction>
    {
        public void Configure(EntityTypeBuilder<AbstractBankTransaction> builder)
        {
            builder.HasDiscriminator();
        }

        public void Configure(EntityTypeBuilder<BetweenCharactersTransaction> builder)
        {
        }

        public void Configure(EntityTypeBuilder<DutyTransaction> builder)
        {
        }

        public void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
        {
        }
    }
}