using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Users.Core.Models;

namespace Users.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<User> ApplyFiltering(this IQueryable<User> query, UserQuery userQuery)
        {
            if (!String.IsNullOrWhiteSpace(userQuery.FullName))
                query = query.Where(u => u.FullName.Contains(userQuery.FullName));

            return query;
        }
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IQueryObject userQuery, Dictionary<string, Expression<Func<T, object>>> sortColumnsMap)
        {
            if (String.IsNullOrWhiteSpace(userQuery.SortBy) || !sortColumnsMap.ContainsKey(userQuery.SortBy))
                return query;

            if (userQuery.IsSortAscending)
                return query.OrderBy(sortColumnsMap[userQuery.SortBy]);
            else
                return query.OrderByDescending(sortColumnsMap[userQuery.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject userQuery)
        {
            if (userQuery.Page <= 0)
                userQuery.Page = 1;

            if (userQuery.PageSize <= 0)
                userQuery.PageSize = 3;

            return query.Skip((userQuery.Page - 1) * userQuery.PageSize).Take(userQuery.PageSize);
        }
    }
}
