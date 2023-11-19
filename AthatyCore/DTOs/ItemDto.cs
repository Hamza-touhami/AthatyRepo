using AthatyCore.Entities;
using System.Text.Json.Serialization;

namespace AthatyCore.DTOs
{
    public record ItemDto
    {
        [JsonPropertyName("Id")]
        public string Id { get; init; } = null!;
        [JsonPropertyName("Title")]
        public string Title { get;init;} = null!;
        [JsonPropertyName("Description")]
        public string Description { get;init;} = null!;
        [JsonPropertyName("Price")]
        public decimal Price {get;init;}
        [JsonPropertyName("CreationDate")]
        public DateTimeOffset CreationDate {get;init;}
        [JsonPropertyName("ProductId")]
        public string ProductId { get; init; } = null!;
        [JsonPropertyName("Address")]
        public AddressInfo Address { get; init; } = null!;
        [JsonPropertyName("Images")]
        public List<Image> Images {get; init;} = null!;

    }
}