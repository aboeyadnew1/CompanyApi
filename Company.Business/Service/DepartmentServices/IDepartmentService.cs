using Company.Business.Dto.Department;
using Company.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.DepartmentServices
{
    public interface IDepartmentService
    {
        Task Add(AddDepartmentDto addDepartmentDto);
        Task<IEnumerable<ReadDepartmentDto>> GetAll();
        Task<ReadDepartmentDto> GetById(int id);
        Task<ReadDepartmentDto> GetByName(string name);
        Task Delete(int id);
        Task Update(ReadDepartmentDto readDepartmentDto);


    }
}
