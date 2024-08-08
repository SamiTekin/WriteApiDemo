using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneUser(User user)
        {
            Create(user);
        }

        public void DeleteOneUser(User user)
        {
            Delete(user);
        }

        public async Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var users= await FindAll(trackChanges)
                .Search(userParameters.SearchTerm)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return PagedList<User>
                .ToPagedList(users, userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<User> GetUsersByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateOneUser(User user)
        {
            Update(user);
        }
    }
}
