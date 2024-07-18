using Company.Business.Dto.Employee;
using Company.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.EmployeeServices
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<ReadEmployeeDto>> GetAll();
        Task<ReadEmployeeDto> GetById(int id);
        Task<ReadEmployeeDto> GetByName(string name);
        Task Add(AddEmployeeDto addEmployeeDto);
        Task Delete(int id);

    }
}
