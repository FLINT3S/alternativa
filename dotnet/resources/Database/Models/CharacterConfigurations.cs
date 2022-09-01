using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Database.Models
{
    internal class CharacterConfigurations : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .Property(c => c.LastPosition)
                .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        s => JsonConvert.DeserializeObject<Vector3>(s)
                    );
            builder.HasMany(c => c.BankAccounts).WithOne();
        }
    }
}