using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Extensions;

namespace Users.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext context;

        public UserRepository(UsersDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(int id, bool includeRelated = true)
        {
            return await context.Users
                                .Include(u => u.Interests)
                                  .ThenInclude(ui => ui.Interest)
                                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<QueryResult<User>> GetUsers(UserQuery userQuery)
        {
            var queryResult = new QueryResult<User>();

            var query = context.Users
                                .Include(u => u.Interests)
                                  .ThenInclude(ui => ui.Interest)
                                .AsQueryable();

            query = query.ApplyFiltering(userQuery);

            var sortColumnsMap = new Dictionary<string, Expression<Func<User, object>>>()
            {
                ["fullName"] = u => u.FullName,
                ["registrationDate"] = u => u.RegistrationDate
            };
            query = query.ApplySorting(userQuery, sortColumnsMap);

            queryResult.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(userQuery);

            var users = await query.ToListAsync();
            queryResult.Items = users;
            return queryResult;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
        }

    }


}
