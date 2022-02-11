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
        private readonly IUserRepository _cuserRepository;
        public UserService(IUserRepository userRepository)
        {
            _cuserRepository = userRepository;
        }

        public async Task<User> SaveAsync(User entity)
        {
            return await _cuserRepository.AddAsync(entity);
        }
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _cuserRepository.GetAllAsync();
        }

    }
}
