using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> SaveAsync(User entity)
        {
            return await _userRepository.AddAsync(entity);
        }
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _userRepository.GetAllAsync();
        }

    }
}
