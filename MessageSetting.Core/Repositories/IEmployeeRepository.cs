using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //custom operations here
        Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname);
    }
}
