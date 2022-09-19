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
            using var file = File.OpenText("dotnet/runtime/hospitalsCoords.json");
            var serializer = new JsonSerializer();
            var jsonReader = new JsonTextReader(file);
            HospitalPositions = serializer.Deserialize<List<Vector3>>(jsonReader);
        }

        public static Vector3 GetNearest(Vector3 playerPosition) => HospitalPositions
            .OrderBy(hospitalPosition => hospitalPosition.DistanceTo2D(playerPosition))
            .First();
    }
}
