using System;
using System.Linq;
using AbstractResource;
using Database;
using Database.Models.Realty;
using DimensionProvider;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using NAPIExtensions;

namespace RoomManager
{
    public class RoomManager : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            using var context = new AltContext();
            foreach (var entrance in context.Entrances.Include(entrance => entrance.Realties))
                SpawnEntrance(entrance);
        }

        private void SpawnEntrance(RealtyEntrance entrance)
        {
            var colshape = NAPI.ColShape.CreateCircleColShape(entrance.Position, DimensionManager.CommonDimension);
            colshape.SetEntrance(entrance);
            NAPI.Marker.CreateRedMarker(entrance.Position, DimensionManager.CommonDimension);
            colshape.SetInteraction(ColShapeInteraction);
        }

        private void ColShapeInteraction(Player player, ColShape shape)
        {
            var entrance = shape.GetEntrance()!;
            bool isHouse = entrance.Realties.Count == 1;
            if (isHouse)
                ClientConnect.TriggerEvent(
                    player, 
                    RoomManagerEvents.OpenHouseInterfaceToClient, 
                    entrance.Realties.First().Id.ToString()
                );
            else
                ClientConnect.TriggerEvent(
                    player,
                    RoomManagerEvents.OpenApartmentHouseInterfaceToClient,
                    entrance.Id.ToString()
                );
        }
        
        [ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColshape(ColShape colshape, Player player) =>
            player.SetPlayerColShape(colshape);

        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColshape(ColShape colshape, Player player) =>
            player.SetPlayerColShape(null);

        [RemoteEvent(RoomManagerEvents.InteractOnColShapeFromClient)]
        public void OnInteractOnColShape(Player player) =>
            player.GetPlayerColShape()?.Interaction(player);

        [RemoteEvent(RoomManagerEvents.EnterToHouseFromCef)]
        public void OnEnterToHouse(Player player, string houseId)
        {
            var house = AltContext.GetRealty(Guid.Parse(houseId));
            // TODO: Загрузка IPL [SERVER:CLIENT:RoomManager:LoadInterior]
            house?.OnPlayerEntrance(player);
        }
    }
}