namespace AthatyCore.DTOs
{
    public record UpdatedItemDto
    {
        public string Name {get;init;} = null!;
        public decimal Price {get;init;}
    }
}