using GTANetworkAPI;

namespace LocationProvider
{
    public static class RealEstateLocationProvider
    {
        public static (Vector3 position, uint dimension) GetLocation(Player player)
        {
            return (Vector3.RandomXy(), 0);
        }
    }
}