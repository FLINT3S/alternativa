using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Economics.CryptoWallets
{
    public class CryptoWalletConfiguration : IEntityTypeConfiguration<CryptoWallet>
    {
        public void Configure(EntityTypeBuilder<CryptoWallet> builder)
        {
            builder.HasKey(cw => cw.Id);

            builder.HasMany(cw => cw.Transactions).WithOne();
        }
    }
}