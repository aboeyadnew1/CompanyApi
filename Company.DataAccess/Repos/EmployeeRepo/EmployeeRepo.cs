using Company.DataAccess.Data;
using Company.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            await _context.Set<Employee>().AddAsync(employee);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var employee = await GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAll()

           =>    await _context.Employees
                             .Include(e => e.Departments) // تضمين بيانات القسم
                             .ToListAsync();

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(e => e.Departments)
                .FirstOrDefaultAsync(e => e.Id == id);

            //var emp = await _context.Employees.FindAsync(id);
            //if (emp == null) return null;
            //return emp;
        }

        public async Task<Employee> GetByName(string name)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(x => x.FirstName == name);
            if (emp == null) return null;
            return emp;
        }

        public void Update(Employee employee)
        {
            _context.SaveChanges();
        }
    }
}
