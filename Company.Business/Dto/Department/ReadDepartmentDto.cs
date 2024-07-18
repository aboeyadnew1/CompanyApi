using Company.Business.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Dto.Department
{
    public class ReadDepartmentDto
    {
        public int Id { get; set; }
        public required string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        ICollection<ReadEmployeeDto> ReadEmployeeDtos { get; set; } = new HashSet<ReadEmployeeDto>();
    }
}
