using System.ComponentModel.DataAnnotations;

namespace AthatyCore.Entities
{
    public class AuthenticationRequest
    {
        [Required]
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
