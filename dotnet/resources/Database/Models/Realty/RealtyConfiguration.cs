using System;
using System.Linq;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Object = System.Object;

namespace Database.Models.Realty
{
    internal class RealtyConfiguration : 
        IEntityTypeConfiguration<Interior>,
        IEntityTypeConfiguration<RealtyPrototype>,
        IEntityTypeConfiguration<Realty>,
        IEntityTypeConfiguration<RealtyEntrance>
    {
        public void Configure(EntityTypeBuilder<Interior> builder)
        {
            builder.HasKey(interior => interior.Id);
            builder
                .Property(interior => interior.Entrance)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );
            builder
                .Property(interior => interior.Exit)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );

            builder.HasData(Data.Realty.Interiors);
        }

        public void Configure(EntityTypeBuilder<RealtyPrototype> builder)
        {
            builder.HasKey(prototype => prototype.Id);
            builder.HasOne(prototype => prototype.Interior);

            builder.HasData(Data.Realty.RealtyPrototypes);
        }

        public void Configure(EntityTypeBuilder<Realty> builder)
        {
            builder.HasKey(realty => realty.Id);
            builder.HasOne(realty => realty.Prototype);
            builder.HasOne(realty => realty.Entrance).WithMany(entrance => entrance.Realties);
        }

        public void Configure(EntityTypeBuilder<RealtyEntrance> builder)
        {
            builder.HasKey(entrance => entrance.Id);
            builder
                .Property(entrance => entrance.Position)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    s => JsonConvert.DeserializeObject<Vector3>(s)
                );
        }
    }
}