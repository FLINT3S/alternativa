using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Economics.CryptoWallets
{
    public class CryptoTransactionConfiguration : IEntityTypeConfiguration<CryptoTransaction>
    {

        public void Configure(EntityTypeBuilder<CryptoTransaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);
        }
    }
}