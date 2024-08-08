using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<(IEnumerable<ExpandoObject> user, MetaData metaData)> GetAllUserAsync(UserParameters userParameters, bool trackChanges);
        Task<UserDto> GetUserByIdAsync(int id, bool trackChanges);
        Task<UserDto> CreateOneUserAyns(UserDtoForInsertion userDto);
        Task UpdateOneUserAyns(int id, UserDtoForUpdate userDto, bool trackChanges);
        Task DeleteUserByIdAsync(int id, bool trackChanges);
    }
}
