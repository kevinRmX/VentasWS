using System.ComponentModel.DataAnnotations;

namespace WSVentas.Models.Request
{
    public class AutRequest
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
