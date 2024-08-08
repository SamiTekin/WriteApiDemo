using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<UserDto> _shaper;

        public UserManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<UserDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<UserDto> CreateOneUserAyns(UserDtoForInsertion userDto)
        {
            var entity= _mapper.Map<User>(userDto);
            _manager.User.CreateOneUser(entity);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(entity);
            

        }

        public async Task DeleteUserByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.User.GetUsersByIdAsync(id, trackChanges);
            if (entity != null)
            {
                throw new UserNotFoundException(id);
            }
            _manager.User.DeleteOneUser(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> user, MetaData metaData)> GetAllUserAsync(UserParameters userParameters, bool trackChanges)
        {
            var usersWithMetaData= await _manager.User.GetAllUsersAsync(userParameters, trackChanges);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);
            var shapedData = _shaper.ShapeData(usersDto, userParameters.Fields);
            return (user: shapedData , metaData: usersWithMetaData.MetaData);
        }

        public async Task<UserDto> GetUserByIdAsync(int id, bool trackChanges)
        {
            var user = await _manager.User.GetUsersByIdAsync(id, trackChanges);
            if(user is null)
                throw new UserNotFoundException(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateOneUserAyns(int id, UserDtoForUpdate userDto, bool trackChanges)
        {
            var entity = await _manager.User.GetUsersByIdAsync(id, trackChanges);
            if(entity is null)
                throw new UserNotFoundException(id);
            entity= _mapper.Map<User>(entity);
            _manager.User.Update(entity);
            await _manager.SaveAsync();

        }
    }
}
