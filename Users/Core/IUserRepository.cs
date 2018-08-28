using System.Threading.Tasks;
using Users.Core.Models;

namespace Users.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id, bool includeRelated = true);
        Task<QueryResult<User>> GetUsers(UserQuery userQuery);
        void Add(User user);
        void Remove(User user);
    }
}