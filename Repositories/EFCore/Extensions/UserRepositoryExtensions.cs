using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> Search(this IQueryable<User> users, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return users;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return users
                .Where(x => x.UserName.ToLower().Contains(lowerCaseTerm) ||
                x.UserSurname.ToLower().Contains(lowerCaseTerm) ||
                x.Email.ToLower().Contains(lowerCaseTerm));
        }
    }
}
