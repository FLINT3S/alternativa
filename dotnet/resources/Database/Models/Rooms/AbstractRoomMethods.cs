using DimensionProvider;
using GTANetworkAPI;

namespace Database.Models.Rooms
{
    public partial class AbstractRoom
    {
        private uint currentDimension;

        public void OnRoomEnter(Character character)
        {
            var player = (Player)character;
            currentDimension = DimensionManager.GetFreeDimension();
            player.Dimension = currentDimension;
            player.Position = Interior;
            Exit.SpawnColShape(currentDimension);
        }
        
        public abstract bool AvailableFor(Character player);
    }
}