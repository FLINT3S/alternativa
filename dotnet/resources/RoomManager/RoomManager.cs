using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace RoomManager
{
    public class RoomManager : AltAbstractResource
    {
        [ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColshape(ColShape colshape, Player player)
        {
            player.SetPlayerColShape(colshape);
        }
        
        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColshape(ColShape colShape, Player player)
        {
            player.SetPlayerColShape(null);
        }
        
        [RemoteEvent(RoomManagerEvents.InteractOnColShapeFromClient)]
        public void OnInteractOnColShape(Player player)
        {
            player.GetPlayerColShape()?.Interaction(player);
        }

        /*[ServerEvent(Event.ResourceStart)]
        public void OnRoomManagerStart()
        {
            var externalColShapes = RoomColShape.GetExternalColShapes();
            foreach (var colShape in externalColShapes)
                SpawnColShapeAndSetListeners(colShape);
        }

        private void SpawnColShapeAndSetListeners(RoomColShape colShape)
        {
            colShape.SpawnColShape();
            colShape.OnEntityEnterColShape += (_, player) => 
                SendEnterColShapeEvent(player, colShape);
            colShape.OnEntityExitColShape += (_, player) =>
                ClientConnect.TriggerEvent(player, RoomManagerEvents.ExitFromExternalRoomColShapeToClient);
        }

        private void SendEnterColShapeEvent(Player player, RoomColShape colShape)
        {
            var rooms = colShape.Rooms;
            if (rooms.Count > 1)
                SendMultiRoomColShapeEnterEvent(player, rooms);
            else
                SendSingleRoomColShapeEnterEvent(player, rooms.FirstOrDefault());
        }

        private void SendSingleRoomColShapeEnterEvent(Player player, AbstractRoom room)
        {
            string roomJson = JsonConvert.SerializeObject(new { room.Id, room.Address });
            ClientConnect.TriggerEvent(player, RoomManagerEvents.EnterInSingleRoomColShapeToClient, roomJson);
        }

        private void SendMultiRoomColShapeEnterEvent(Player player, IEnumerable<AbstractRoom> rooms)
        {
            var simplifiedRooms = rooms.Select(r => new { r.Id, r.Address }).ToList();
            string roomsJson = JsonConvert.SerializeObject(simplifiedRooms);
            ClientConnect.TriggerEvent(player, RoomManagerEvents.EnterInMultiRoomColShapeToClient, roomsJson);
        }

        [RemoteEvent(RoomManagerEvents.EnterInRoomFromCef)]
        public void OnSelectRoom(Player player, string roomGuidString)
        {
            var roomGuid = Guid.Parse(roomGuidString);
            var room = AltContext.GetRoom(roomGuid);
            var character = player.GetCharacter();
            if (!room.AvailableFor(character))
                CefConnect.TriggerEvent(player, RoomManagerEvents.EnterInRoomFailureToClient);
            else
                OnSuccessEnter(room, character);
        }

        private void OnSuccessEnter(AbstractRoom room, Character character)
        {
            room.Exit.OnEntityEnterColShape += (_, client) => 
                ClientConnect.TriggerEvent(client, RoomManagerEvents.EnterInInternalRoomColShapeToClient);
            room.Exit.OnEntityExitColShape += (_, client) => 
                ClientConnect.TriggerEvent(client, RoomManagerEvents.ExitFromInternalRoomColShapeToClient);
            room.OnRoomEnter(character);
        }

        [RemoteEvent(RoomManagerEvents.ExitFromRoomFromCef)]
        public void OnExitFromRoom(Player player, string roomGuidString)
        {
            var roomGuid = Guid.Parse(roomGuidString);
            var room = AltContext.GetRoom(roomGuid);
            room.OnRoomExit(player.GetCharacter());
        }*/
    }
}