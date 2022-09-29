using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Database.Models.RealEstate
{
    internal class RealEstateConfiguration : 
        IEntityTypeConfiguration<AbstractRoom>,
        IEntityTypeConfiguration<AbstractRealEstate>,
        IEntityTypeConfiguration<House>,
        IEntityTypeConfiguration<Garage>
    {

        public void Configure(EntityTypeBuilder<AbstractRoom> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(are => are.Entrance)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );
            builder.Property(h => h.Exit)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );
            builder.Property(h => h.Interior)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );
        }

        public void Configure(EntityTypeBuilder<AbstractRealEstate> builder)
        {
        }

        public void Configure(EntityTypeBuilder<House> builder)
        {
        }

        public void Configure(EntityTypeBuilder<Garage> builder)
        {
        }

    }
}