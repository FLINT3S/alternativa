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
            throw new System.NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<BetweenCharactersTransaction> builder)
        {
            throw new System.NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<DutyTransaction> builder)
        {
            throw new System.NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}