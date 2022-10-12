using GTANetworkAPI;
using Marker = GTANetworkMethods.Marker;

namespace NAPIExtensions
{
    public static class MarkersExtensions
    {
        public static void CreateRedMarker(this Marker marker, Vector3 position, uint dimension) =>
            NAPI.Marker.CreateMarker(
                1, 
                position, 
                new Vector3(), 
                new Vector3(), 
                1, 
                255, 
                0, 
                0, 
                false, 
                dimension
            );
    }
}