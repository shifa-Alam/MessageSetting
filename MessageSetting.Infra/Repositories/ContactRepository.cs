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
        private MessageSettingDbContext _messageSettingDbContext;
        public ContactRepository(MessageSettingDbContext messageSettingDbContext) : base(messageSettingDbContext) 
        {
            _messageSettingDbContext = messageSettingDbContext;
        }
    }
}
