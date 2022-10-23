using GTANetworkAPI;

namespace Database.Models
{
    public partial class CharacterSpawnData
    {
        public void Save(Player player)
        {
            Armor = player.Armor;
            Health = player.Health;

            Position = Owner.CurrentRoom == null ? player.Position : Owner.CurrentRoom.Entrance.Position;
            Heading = player.Heading;
            Dimension = 0U;
        }
    }
}