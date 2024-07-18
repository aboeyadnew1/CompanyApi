using Company.Business.Dto.Department;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.DepartmentRepo;

namespace Company.Business.Service.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task Add(AddDepartmentDto addDepartmentDto)
        {
            var dep = new Department
            {
                DepartmentName = addDepartmentDto.DepartmentName,
                Description = addDepartmentDto.Description,
                Notes = addDepartmentDto.Notes,
            };
            await _departmentRepository.Add(dep);
        }


        public async Task Delete(int id)
        {
            await _departmentRepository.Delete(id);
        }

        public async Task<IEnumerable<ReadDepartmentDto>> GetAll()
        {

            var depDb = await _departmentRepository.GetAll();
            // Maping From Db to Dto
            return depDb.Select(x => new ReadDepartmentDto
            {
                DepartmentName = x.DepartmentName,
                Description = x.Description,
                Notes = x.Notes,
                Id= x.Id
            }).ToList();
        }

        public async Task<ReadDepartmentDto> GetById(int id)
        {
            var depDb = await _departmentRepository.GetById(id);
            if (depDb == null)
            {
                return null;
            }
            else
            {
                return new ReadDepartmentDto
                {
                    DepartmentName = depDb.DepartmentName,
                    Description = depDb.Description,
                    Notes = depDb.Notes,
                    Id = depDb.Id
                };
            }
        }

        public async Task<ReadDepartmentDto> GetByName(string name)
        {
            var depDb = await _departmentRepository.GetByName(name);
            if (depDb == null)
            {
                return null;
            }
            else
            {
                return new ReadDepartmentDto
                {
                    DepartmentName = depDb.DepartmentName,
                    Description = depDb.Description,
                    Notes = depDb.Notes,
                    Id = depDb.Id
                };
            }
        }

        public async Task Update(ReadDepartmentDto readDepartmentDto)
        {
            var existingDepartment = await _departmentRepository.GetById(readDepartmentDto.Id);
            if (existingDepartment == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            existingDepartment.DepartmentName = readDepartmentDto.DepartmentName;
            existingDepartment.Description = readDepartmentDto.Description;
            existingDepartment.Notes = readDepartmentDto.Notes;
            await _departmentRepository.Update(existingDepartment);
        }
    }
}
