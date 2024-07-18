using Company.Business.Dto.Department;
using Company.Business.Dto.Employee;
using Company.Business.Service.DepartmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
           _departmentService = departmentService;
        }
        [HttpGet]
        public async Task <ActionResult<IEnumerable<ReadDepartmentDto>>> GetAll() 
        {
        var Dep = await _departmentService.GetAll();
            if (Dep == null) return null;
            return Ok(Dep);
        }
        [HttpPost]
        public async Task<ActionResult<AddDepartmentDto>> Add(AddDepartmentDto  addDepartmentDto)
        {
            await _departmentService.Add(addDepartmentDto);
            return Ok("Department Add Successfully");
        }
    }
}
