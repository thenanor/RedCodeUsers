using System.ComponentModel.DataAnnotations;

namespace Users.Controllers.Dtos
{
    public class ContactDto
    {
        [Required]
        [StringLength(255)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }
    }
}
