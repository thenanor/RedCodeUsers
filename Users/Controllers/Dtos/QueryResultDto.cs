using System.Collections.Generic;

namespace Users.Controllers.Dtos
{
    public class QueryResultDto<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
