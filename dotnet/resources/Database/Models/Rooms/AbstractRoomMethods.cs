using System;
using System.Linq;
using DimensionProvider;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database.Models.Rooms
{
    public partial class AbstractRoom
    {
        private uint currentDimension;

        public void OnRoomEnter(Character character, Action onExitAction)
        {
            currentDimension = DimensionManager.GetFreeDimension();
            
            var player = (Player)character;
            player.Dimension = currentDimension;
            player.Position = Interior;

            Entrance = LoadEntrance();
            Exit = LoadExit();
            
            Exit.SpawnColShape(currentDimension);
        }

        private RoomColShape LoadEntrance()
        {
            using var context = new AltContext();
            return context.RoomColShapes
                .Include(rcs => rcs.Rooms)
                .First(rcs => rcs.Rooms.Contains(this));
        }

        private RoomColShape LoadExit()
        {
            using var context = new AltContext();
            return context.RoomColShapes
                .First(rcs => rcs.Owner == this);
        }

        public void OnRoomExit(Player player)
        {
            player.Dimension = DimensionManager.CommonDimension;
            player.Position = Entrance.Center;
        }
        
        public abstract bool AvailableFor(Character player);
    }
}