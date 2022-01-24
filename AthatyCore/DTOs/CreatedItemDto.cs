namespace AthatyCore.DTOs
{
    public record CreatedItemDto
    {
        public string Name {get;init;} = null!;
        public decimal Price {get;init;}
    }
}