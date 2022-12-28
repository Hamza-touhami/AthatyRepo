using System.ComponentModel.DataAnnotations;

namespace AthatyCore.Entities
{
    public record Collection
    {
        [Key]
        public string Id { get; set; } //init is used for immutable properties
    }
}
