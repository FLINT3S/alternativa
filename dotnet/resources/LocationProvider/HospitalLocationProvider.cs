using System.Collections.Generic;
using System.IO;
using System.Linq;
using AbstractResource;
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

        public static Vector3 GetNearestHospitalCoords(Vector3 position) => HospitalPositions
            .ToDictionary(hospitalPosition => hospitalPosition.DistanceTo2D(position))
            .OrderBy(pair => pair.Key)
            .First()
            .Value;
    }
}
