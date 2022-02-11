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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private MessageSettingDbContext _messageSettingDbContext;
        public EmployeeRepository(MessageSettingDbContext messageSettingDbContext) : base(messageSettingDbContext) 
        {
            _messageSettingDbContext = messageSettingDbContext;
        }
        public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname)
        {
            return await _messageSettingDbContext.Employees.Where(m => m.LastName == lastname).ToListAsync();
        }

        Task<IEnumerable<Employee>> IEmployeeRepository.GetEmployeeByLastName(string lastname)
        {
            throw new NotImplementedException();
        }
    }
}
