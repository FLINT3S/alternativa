using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using DimensionProvider;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database.Models.Rooms
{
    public partial class AbstractRoom
    {
        private uint currentDimension;

        private readonly List<Character> guests = new List<Character>();

        public void OnRoomEnter(Character character)
        {
            if (guests.IsNullOrEmpty()) LoadInterior();
            guests.Add(character);
            MoveInInterior((Player)character);
        }

        private void LoadInterior()
        {
            currentDimension = DimensionManager.GetFreeDimension();
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

        private void MoveInInterior(Entity player)
        {
            player.Dimension = currentDimension;
            player.Position = Interior;
        }

        public void OnRoomExit(Character character)
        {
            MoveFromInterior((Player)character);
            guests.Remove(character);
            if (guests.IsNullOrEmpty()) Exit.DeleteColShape();
        }

        private void MoveFromInterior(Entity player)
        {
            player.Dimension = DimensionManager.CommonDimension;
            player.Position = Entrance.Center;
        }
        
        public abstract bool AvailableFor(Character character);
    }
}