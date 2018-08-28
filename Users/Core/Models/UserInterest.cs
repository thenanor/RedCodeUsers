using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Core.Models
{
    [Table("UserInterests")]
    public class UserInterest
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
