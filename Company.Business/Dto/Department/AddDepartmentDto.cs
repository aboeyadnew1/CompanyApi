using Company.Business.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Dto.Department
{
    public class AddDepartmentDto
    {
        public required string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        ICollection<AddEmployeeDto> AddEmployeeDtos { get; set; } = new HashSet<AddEmployeeDto>();
    }
}
