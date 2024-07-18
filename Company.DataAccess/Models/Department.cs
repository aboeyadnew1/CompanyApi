using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string DepartmentName { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public  ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
