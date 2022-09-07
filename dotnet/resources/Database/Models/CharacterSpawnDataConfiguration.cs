using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Database.Models
{
    public class CharacterSpawnDataConfiguration : IEntityTypeConfiguration<CharacterSpawnData>
    {
        public void Configure(EntityTypeBuilder<CharacterSpawnData> builder)
        {
            builder.HasKey(sd => sd.Id);
            builder
                .Property(sd => sd.Position)
                .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        s => JsonConvert.DeserializeObject<Vector3>(s)
                    );
        }
    }
}