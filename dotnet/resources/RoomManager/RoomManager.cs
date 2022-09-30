using System;
using System.Linq;
using GTANetworkAPI;
using AbstractResource;
using Database;
using Database.Models.Rooms;
using NAPIExtensions;
using Newtonsoft.Json;

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
                    var rooms = colShape.Rooms.Select(r => new { r.Id, r.Address }).ToList();
                    if (rooms.Count > 1)
                    {
                        string roomJson = JsonConvert.SerializeObject(rooms.FirstOrDefault());
                        ClientConnect.Trigger(player, RoomManagerEvents.OnMonoRoomHouseColShapeEnterToClient, roomJson);
                    }
                    else
                    {
                        string roomsJson = JsonConvert.SerializeObject(rooms);
                        ClientConnect.Trigger(player, RoomManagerEvents.OnPolyRoomHouseColShapeEnterToClient, roomsJson);
                    }
                };
                colShape.OnEntityExitColShape += (shape, player) =>
                    ClientConnect.Trigger(player, RoomManagerEvents.OnColShapeExitToClient);
            }
        }

        [RemoteEvent(RoomManagerEvents.EnterInRoomFromCef)]
        public void OnSelectRoom(Player player, string roomGuidString)
        {
            var roomGuid = Guid.Parse(roomGuidString);
            var room = AltContext.GetRoom(roomGuid);
            var character = player.GetCharacter();
            if (!room.AvailableFor(character))
            {
                ClientConnect.Trigger(player, RoomManagerEvents.OnEnterFailureToCef);
                return;
            }
            
            room.OnRoomEnter(character);
        }
    }
}
