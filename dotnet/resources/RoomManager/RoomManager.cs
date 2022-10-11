using System.Linq;
using AbstractResource;
using Database;
using Database.Models.Realty;
using DimensionProvider;
using GTANetworkAPI;
using NAPIExtensions;

namespace RoomManager
{
    public class RoomManager : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            using var context = new AltContext();
            foreach (var entrance in context.Entrances)
                SpawnEntrance(entrance);
        }

        public void SpawnEntrance(RealtyEntrance entrance)
        {
            var colshape = NAPI.ColShape.CreatCircleColShape(
                entrance.Position.X, 
                entrance.Position.Y, 
                1f, 
                DimensionManager.CommonDimension
            );
            colshape.SetInteraction((player, shape) =>
            {
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
            });
        }
        
        [ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColshape(ColShape colshape, Player player)
        {
            player.SetPlayerColShape(colshape);
        }
        
        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColshape(ColShape colshape, Player player)
        {
            player.SetPlayerColShape(null);
        }
        
        [RemoteEvent(RoomManagerEvents.InteractOnColShapeFromClient)]
        public void OnInteractOnColShape(Player player)
        {
            player.GetPlayerColShape()?.Interaction(player);
        }
    }
}