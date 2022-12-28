namespace AthatyCore.DTOs
{
    public record ProductDto
    {
        public string Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
        public string CategoryId {get;init;}
    }
}