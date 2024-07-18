using Company.Business.Dto.Employee;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.DepartmentRepo;
using Company.DataAccess.Repos.EmployeeRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeServices(IEmployeeRepo employeeRepo , IDepartmentRepository departmentRepository)
        {
            _employeeRepo = employeeRepo;
           _departmentRepository = departmentRepository;
        }
        public async Task Add(AddEmployeeDto addEmployeeDto)
        {
            if (addEmployeeDto.DepartmentId == null)
            throw new KeyNotFoundException("Department not found. Please Add Department First");
            
            var emp = new Employee
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                PhoneNumber = addEmployeeDto.PhoneNumber,
                JopTitle = addEmployeeDto.JopTitle,
                Salary = addEmployeeDto.Salary,
                FullName = addEmployeeDto.FullName,
                DepartmentId = addEmployeeDto.DepartmentId,
               
            };
            await _employeeRepo.Add(emp);

        }


        public async Task Delete(int id)
        {
            await _employeeRepo.Delete(id);
        }
        public async Task<IEnumerable<ReadEmployeeDto>> GetAll()
        {
            var emp = await _employeeRepo   .GetAll();
            return emp.Select(x => new ReadEmployeeDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                JopTitle = x.JopTitle,
                Salary = x.Salary,
                FullName= x.FullName,
                Id = x.Id,
                DepartmentName = x.Departments?.DepartmentName
            }).ToList();
        }

        public async Task<ReadEmployeeDto> GetById(int id)
        {
            var employee = await _employeeRepo.GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            var department = await _departmentRepository.GetById(employee.DepartmentId);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            return new ReadEmployeeDto
            {
                Id = employee.Id,
                FullName = employee.FullName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                JopTitle = employee.JopTitle,
                DepartmentName = employee.Departments?.DepartmentName
            };
        }

        public async Task<ReadEmployeeDto> GetByName(string name)
        {
            var empdb = await _employeeRepo.GetByName(name);
            if (empdb == null) return null; 
            return new ReadEmployeeDto
            {
                FirstName=empdb.FirstName,
                LastName=empdb.LastName,
                PhoneNumber = empdb.PhoneNumber,
                Salary=empdb.Salary,
                JopTitle=empdb.JopTitle,
                FullName = empdb.FullName,
                Id = empdb.Id,
                DepartmentName = empdb.Departments.DepartmentName
            };
        }
    }
}
