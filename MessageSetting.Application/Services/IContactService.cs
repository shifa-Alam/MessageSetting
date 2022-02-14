using MessageSetting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public interface IContactService
    {
        public Task<Contact> SaveAsync(Contact entity);
        //public Task UpdateAsync(Contact entity);
        //public Task<Contact> FindByIdAsync(long id); 
        //public Task DeleteAsync(Contact entity);
        public Task<IEnumerable<Contact>> GetAsync();
        public Task<IEnumerable<Contact>> GetAllWithChildAsync();
        public void UpdateRange(IList<Contact> contacts);
    }
}
