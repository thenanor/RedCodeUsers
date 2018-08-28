using System.ComponentModel.DataAnnotations;

namespace Users.Core.Models
{
    public class Interest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
