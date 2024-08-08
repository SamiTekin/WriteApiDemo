using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        Task <PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges);
        Task<User> GetUsersByIdAsync (int id, bool trackChanges);
        void DeleteOneUser(User user);
        void CreateOneUser(User user);
        void UpdateOneUser(User user);
    }
}
