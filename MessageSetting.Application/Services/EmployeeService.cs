using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository Repo;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            Repo = employeeRepository;
        }

        public async Task<Employee> SaveAsync(Employee entity)
        {
            Repo.AddAsync(entity);
            Repo.SaveChanges();
            return entity;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            return entity;
        }
        public async Task DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> FindByIdAsync(long id)
        {
            var employee = new Employee { Id = 10, FirstName = "Shifa" };
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            IList<Employee> list = new List<Employee>();
            list.Add(new Employee { Id=10, FirstName="Shifa"});
            return list;
           
        }
    }
}
