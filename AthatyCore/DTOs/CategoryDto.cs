using System.Text.Json.Serialization;

namespace AthatyCore.DTOs
{
    public record CategoryDto
    {
        [JsonPropertyName("Id")] //Done specifically to avoid lowercase serialization
        public string Id {get;init;} //init is used for immutable properties
        [JsonPropertyName("Name")] 
        public string Name {get;init;} = null!;
    }
}