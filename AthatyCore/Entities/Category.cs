namespace AthatyCore.Entities
{
    public record Category
    {
        public Guid Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
        public List<Product> Products {get;init;} = new List<Product>();
    }
}