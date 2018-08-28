using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Users.Controllers.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public char Gender { get; set; }

        public ICollection<InterestDto> Interests { get; set; }

        public ContactDto Contact { get; set; }

        public DateTime RegistrationDate { get; set; }

        public UserDto()
        {
            Interests = new Collection<InterestDto>();
        }
    }
}
