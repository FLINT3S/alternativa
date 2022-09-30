using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Database.Models
{
    public class ColShapeConfiguration : IEntityTypeConfiguration<ColShape>
    {
        public void Configure(EntityTypeBuilder<ColShape> builder)
        {
            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.Center)
                .HasConversion(
                    vector => JsonConvert.SerializeObject(vector), 
                    json => JsonConvert.DeserializeObject<Vector3>(json)
                );
        }
    }
}