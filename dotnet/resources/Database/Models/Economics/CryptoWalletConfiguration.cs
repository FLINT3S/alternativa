using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Economics
{
    public class CryptoWalletConfiguration : IEntityTypeConfiguration<CryptoWallet>
    {
        public void Configure(EntityTypeBuilder<CryptoWallet> builder)
        {
            builder.HasKey(cw => cw.Id);
        }
    }
}