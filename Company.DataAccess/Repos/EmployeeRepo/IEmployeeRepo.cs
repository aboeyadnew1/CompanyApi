using Company.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.EmployeeRepo
{
    public interface IEmployeeRepo
    {
       Task< IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> GetByName(string name);
        Task Add(Employee employee);
        void Update(Employee employee);
        Task Delete(int id);
    }
}
