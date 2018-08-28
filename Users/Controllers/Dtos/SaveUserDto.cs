using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Users.Controllers.Dtos
{
    public class SaveUserDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public char Gender { get; set; }

        public ICollection<int> Interests { get; set; }

        public ContactDto Contact { get; set; }

        public SaveUserDto()
        {
            Interests = new Collection<int>();
        }
    }
}
