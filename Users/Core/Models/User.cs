using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Users.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public char Gender { get; set; }

        public ICollection<UserInterest> Interests { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactAddress { get; set; }

        public DateTime RegistrationDate { get; set; }

        public User()
        {
            Interests = new Collection<UserInterest>();
        }
    }
}
