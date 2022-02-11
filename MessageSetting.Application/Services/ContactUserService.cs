using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public class ContactUserService : IContactUserService
    {
        private readonly IContactUserRepository _contactUserRepository;
        public ContactUserService(IContactUserRepository contactUserRepository)
        {
            _contactUserRepository = contactUserRepository;
        }

       
        public async Task<ContactUser> SaveAsync(ContactUser entity)
        {
            return await _contactUserRepository.AddAsync(entity);
        }
        public async Task<IEnumerable<ContactUser>> GetAsync()
        {
            return await _contactUserRepository.GetAllAsync();
        }

        //public void OnContactSave(Contact entity)
        //{
           

        //    try
        //    {
        //        if (entity is null)
        //        {
        //            throw new ArgumentNullException(nameof(entity));
        //        }
        //        foreach (var item in entity.ContactUsers)
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
