using GTANetworkAPI;

namespace Database.Models
{
    public partial class CharacterSpawnData
    {
        public void OnDisconnect(Player player)
        {
            Armor = player.Armor;
            Health = player.Health;

            Position = player.Position;
            Heading = player.Heading;
        }

        public void OnRespawn() => Health = 100;
    }
}