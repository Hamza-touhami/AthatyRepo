namespace AthatyCore.DTOs
{
    public record UpdatedProductDto
    {
        public string Name {get;init;} = null!;
        public string CategoryId {get;init;} = null!;
    }
}