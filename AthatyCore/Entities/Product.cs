using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthatyCore.Entities
{
    public record Product
    {
        [Key]
        public Guid Id {get;init;} //init is used for immutable properties
        [Required]
        [MaxLength(50)]
        public string Name {get;init;} = null!;
        [ForeignKey("category")]
        public Guid CategoryId {get;init;}
    }
}