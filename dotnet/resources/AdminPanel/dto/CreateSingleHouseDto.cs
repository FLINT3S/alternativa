using System.Text.Json.Serialization;
using GTANetworkAPI;

namespace AdminPanel.dto
{
    public class CreateSingleHouseDto
    {
        [JsonPropertyName("prototypeGuid")] public string PrototypeGuid { get; set; }
        
        [JsonPropertyName("position")] public Vector3 Position { get; set; }
    }
}