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
        private readonly MessageSettingDbContext _messageSettingDbContext;
        public ContactRepository(MessageSettingDbContext messageSettingDbContext) : base(messageSettingDbContext) 
        {
            _messageSettingDbContext = messageSettingDbContext;
        }

        public IEnumerable<Contact> GetAllWithChild()
        {
            //Include(co => co.Employees).ThenInclude(emp => emp.Employee_Car)
            // .Include(co => co.Employees).ThenInclude(emp => emp.Employee_Country)
            // .FirstOrDefault(co => co.companyID == companyID)

            var results = _messageSettingDbContext.Contacts.Include(e=>e.ContactUsers).ToList();
            //_messageSettingDbContext.Users.Where(e=>e.Id).ToList();
            return results;
        }

        public void UpdateRangeAsync(IList<Contact> contacts)
        {
            _messageSettingDbContext.Contacts.UpdateRange(contacts);
        }
    }
}
