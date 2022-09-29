using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace LocationProvider
{
    public static class HospitalLocationProvider
    {
        private static List<Vector3> HospitalPositions { get; }
        
        static HospitalLocationProvider()
        {
            string file = File.ReadAllText("places/hospitals.json");
            HospitalPositions = JsonConvert.DeserializeObject<List<Vector3>>(file);
        }

        public static (Vector3 position, uint dimension) GetLocation(Vector3 playerPosition) => 
        (
            HospitalPositions.OrderBy(hospitalPosition => hospitalPosition.DistanceTo2D(playerPosition)).First(),
            DimensionProvider.CommonDimension
        );

        public static float GetDistance(Vector3 playerPosition) => HospitalPositions
            .Min(hospitalPosition => hospitalPosition.DistanceTo2D(playerPosition));
    }
}
