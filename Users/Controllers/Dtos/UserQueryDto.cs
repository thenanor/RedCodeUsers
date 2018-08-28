using Users.Extensions;

namespace Users.Controllers.Dtos
{
    public class UserQueryDto : IQueryObject
    {
        public string FullName { get; set; }

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }

    }
}
