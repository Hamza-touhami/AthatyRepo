namespace AthatyCore.DTOs
{
    public record ProductDto
    {
        public Guid Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
        public Guid CategoryId {get;init;}
    }
}