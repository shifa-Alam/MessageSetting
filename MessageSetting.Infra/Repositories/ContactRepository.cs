using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories;
using MessageSetting.Infra.Data;
using MessageSetting.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Infra.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(MessageSettingDbContext messageSettingDbContext) :
            base(messageSettingDbContext)
        {
        }
        public IEnumerable<Contact> GetAllIncludeChild()
        {
            var dbResult = _messageSettingDbContext.Contacts.Include(e=>e.ContactUsers).ToListAsync();
            return dbResult.Result;
        }

        public void UpdateRangeAsync(IEnumerable<Contact> contacts)
        {
            _messageSettingDbContext.Contacts.UpdateRange(contacts);
        }


        public void UpdateParentWithChild(Contact entity)
        {
            var existingParent = _messageSettingDbContext.Contacts
                .Where(p => p.Id == entity.Id)
                .Include(p => p.ContactUsers)
                .SingleOrDefault();

            if (existingParent != null)
            {
                // Update parent
                _messageSettingDbContext.Entry(existingParent).CurrentValues.SetValues(entity);

                // Delete children
                foreach (var existingChild in existingParent.ContactUsers.ToList())
                {
                    if (!entity.ContactUsers.Any(c => c.Id == existingChild.Id))
                        _messageSettingDbContext.ContactUsers.Remove(existingChild);
                }

                // Update and Insert children
                foreach (var childModel in entity.ContactUsers)
                {
                    var existingChild = existingParent.ContactUsers
                        .Where(c => c.Id == childModel.Id && c.Id != default(int))
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _messageSettingDbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = new ContactUser()
                        {
                            UserId = childModel.UserId,
                            UserType = childModel.UserType
                        };
                        existingParent.ContactUsers.Add(newChild);
                    }
                }
            }

            _messageSettingDbContext.SaveChanges();
        }
    }
}
