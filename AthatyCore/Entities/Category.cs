using System.ComponentModel.DataAnnotations;

namespace AthatyCore.Entities
{
    public record Category
    {
        [Key]
        public Guid Id {get;init;} //init is used for immutable properties
        [Required]
        [MaxLength(50)]
        public string Name {get;init;} = null!;
    }
}