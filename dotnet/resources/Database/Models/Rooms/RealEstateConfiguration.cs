using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Database.Models.Rooms
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
            builder
                .HasOne(are => are.Entrance)
                .WithMany(cs => cs.Rooms);
            builder
                .HasOne(are => are.Exit)
                .WithOne(rcs => rcs.Owner)
                .HasForeignKey<RoomColShape>(rcs => rcs.OwnerId);
            builder.Property(ar => ar.Interior)
                .HasConversion(
                    vector => JsonConvert.SerializeObject(vector), 
                    json => JsonConvert.DeserializeObject<Vector3>(json)
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