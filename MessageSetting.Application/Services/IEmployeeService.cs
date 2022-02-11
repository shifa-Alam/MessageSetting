using MessageSetting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> SaveAsync(Employee entity);
        public Task<Employee> UpdateAsync(Employee entity);
        public Task<Employee> FindByIdAsync(long id); 
        public Task DeleteAsync(Employee entity);
        public Task<IEnumerable<Employee>> GetAsync();

    }
}
