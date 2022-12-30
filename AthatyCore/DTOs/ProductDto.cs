using System.Text.Json.Serialization;

namespace AthatyCore.DTOs
{
    public record ProductDto
    {
        [JsonPropertyName("Id")]
        public string Id {get;init;} //init is used for immutable properties
        [JsonPropertyName("Name")]
        public string Name {get;init;} = null!;
        [JsonPropertyName("CategoryId")]
        public string CategoryId {get;init;}
    }
}