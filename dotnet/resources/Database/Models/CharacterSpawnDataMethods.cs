using GTANetworkAPI;

namespace Database.Models
{
    public partial class CharacterSpawnData
    {
        public void Save(Player player)
        {
            Armor = player.Armor;
            Health = player.Health;

            Position = player.Position;
            Heading = player.Heading;
            Dimension = 0U; // Owner.CurrentRoom != null ? player.Dimension : 0U;
        }
    }
}