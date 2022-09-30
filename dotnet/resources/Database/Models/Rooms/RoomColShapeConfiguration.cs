using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models.Rooms
{
    public class RoomColShapeConfiguration : IEntityTypeConfiguration<RoomColShape>
    {
        public void Configure(EntityTypeBuilder<RoomColShape> builder)
        {
        }
    }
}