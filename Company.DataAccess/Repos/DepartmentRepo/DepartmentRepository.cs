using Company.DataAccess.Data;
using Company.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task Add(Department Department)
        {
            await _context.Set<Department>().AddAsync(Department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var department = await GetById(id);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()

          => await _context.Set<Department>().ToListAsync();
        public async Task<Department> GetById(int id)
        {
            var dep = await _context.Departments.FindAsync(id);
            if (dep == null) return null;
            return dep;
        }

        public async Task<Department> GetByName(string name)
        {
            var dep = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentName == name);
            if (dep == null) return null;
            return dep;
        }

        public async Task Update(Department department)
        {
            var existingEmployee = await GetById(department.Id);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            existingEmployee.DepartmentName = department.DepartmentName;
            existingEmployee.Description = department.Description;
            existingEmployee.Notes = department.Notes;
            

            _context.Set<Department>().Update(existingEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
