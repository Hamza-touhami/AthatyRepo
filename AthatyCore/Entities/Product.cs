using AthatyCore.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthatyCore.Entities
{
    public record Product : Collection
    {
        [MaxLength(50)]
        public string Name {get;set;}
        [ForeignKey("category")]
        public string CategoryId {get;set;}

  
    }
}