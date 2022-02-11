using MessageSetting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public interface IUserService
    {
        public Task<User> SaveAsync(User entity);
        //public Task UpdateAsync(Contact entity);
        //public Task<Contact> FindByIdAsync(long id); 
        //public Task DeleteAsync(Contact entity);
        public Task<IEnumerable<User>> GetAsync();

    }
}
