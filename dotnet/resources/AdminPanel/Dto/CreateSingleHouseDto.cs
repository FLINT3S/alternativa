using System.Text.Json.Serialization;
using GTANetworkAPI;

namespace AdminPanel.Dto
{
    public class CreateSingleHouseDto
    {
        [JsonPropertyName("prototypeGuid")] public string PrototypeGuid { get; set; } = null!;
        
        [JsonPropertyName("position")] public Vector3 Position { get; set; } = null!;
    }
}