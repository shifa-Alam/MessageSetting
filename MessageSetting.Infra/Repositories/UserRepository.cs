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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private MessageSettingDbContext _messageSettingDbContext;
        public UserRepository(MessageSettingDbContext messageSettingDbContext) : base(messageSettingDbContext) 
        {
            _messageSettingDbContext = messageSettingDbContext;
        }
    }
}
