﻿using Company.Business.Dto.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Dto.Employee
{
    public class AddEmployeeDto
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public double Salary { get; set; }
        public string JopTitle { get; set; }
        public int DepartmentId { get; set; }
    }
}
