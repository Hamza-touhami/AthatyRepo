namespace AthatyCore.DTOs
{
    public record UpdatedItemDto
    {
        public string Description { get;init;} = null!;
        public decimal Price {get;init;}
        public string ProductId { get; init; } = null!;
        public string Title { get; init; } = null!;
        public List<Image> Images {get; set;} = new List<Image>();
    }
}