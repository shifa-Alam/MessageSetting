using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IContactUserService _contactUserService;

        public ContactService(IContactRepository contactRepository,
            IContactUserService contactUserService)
        {
            _repo = contactRepository;
            _contactUserService = contactUserService;
        }

        public async Task<Contact> SaveAsync(Contact entity)
        {
            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                _repo.AddAsync(entity);
                _repo.SaveChanges();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public  void UpdateRange(IList<Contact> contacts)
        {
            try
            {
                foreach (Contact contact in contacts)
                {
                    _repo.UpdateParentWithChild(contact);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<Contact>> GetAsync()
        {

            return await _repo.GetAllAsync();

        }

        public async Task<IEnumerable<Contact>> GetAllWithChildAsync()
        {
            return _repo.GetAllIncludeChild();
        }










        //public async Task UpdateAsync(Contact entity)
        //{
        //    await _contactRepository.UpdateAsync(entity);
        //}
        //public async Task DeleteAsync(Contact entity)
        //{
        //    await _contactRepository.DeleteAsync(entity);
        //}
        //public async Task<Contact> FindByIdAsync(long id)
        //{
        //    return await _contactRepository.GetByIdAsync(id); ;
        //}
    }
}
