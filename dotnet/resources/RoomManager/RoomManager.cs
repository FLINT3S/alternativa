using System;
using System.Linq;
using AbstractResource;
using Database;
using Database.Models.Rooms;
using GTANetworkAPI;
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
                SpawnColShapeAndSetListeners(colShape);
        }

        private void SpawnColShapeAndSetListeners(RoomColShape colShape)
        {
            colShape.SpawnColShape();
            colShape.OnEntityEnterColShape += (_, player) => SendEnterColShapeEvent(player, colShape);
            colShape.OnEntityExitColShape += (_, player) =>
                ClientConnect.Trigger(player, RoomManagerEvents.OnColShapeExitToClient);
        }

        private void SendEnterColShapeEvent(Player player, RoomColShape colShape)
        {
            var rooms = colShape.Rooms.Select(r => new { r.Id, r.Address }).ToList();
            string roomsJson = rooms.Count > 1 ?
                JsonConvert.SerializeObject(rooms.FirstOrDefault()) :
                JsonConvert.SerializeObject(rooms);
            ClientConnect.Trigger(player,
                rooms.Count > 1 ?
                    RoomManagerEvents.OnPolyRoomHouseColShapeEnterToClient :
                    RoomManagerEvents.OnMonoRoomHouseColShapeEnterToClient,
                roomsJson
            );
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