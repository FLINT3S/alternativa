using System.Linq;
using GTANetworkAPI;
using AbstractResource;
using Database.Models.Rooms;

namespace RoomManager
{
    public class RoomManager : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnRoomManagerStart()
        {
            var externalColShapes = RoomColShape.GetExternalColShapes();
            foreach (var colShape in externalColShapes)
            {
                colShape.SpawnColShape();
                colShape.OnEntityEnterColShape += (shape, player) =>
                {
                    var rooms = colShape.Rooms.Select(r => r.Id);
                };
            }
        }
    }
}
