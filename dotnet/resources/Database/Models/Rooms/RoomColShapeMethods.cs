using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Database.Models.Rooms
{
    public partial class RoomColShape
    {
        public static IEnumerable<RoomColShape> GetExternalColShapes()
        {
            using var context = new AltContext();
            return context.RoomColShapes
                .Include(rcs => rcs.Rooms)
                .Where(rcs => !rcs.IsInternal);
        }
    }
}