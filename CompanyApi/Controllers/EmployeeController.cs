using Company.Business.Dto.Employee;
using Company.Business.Service.EmployeeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeeDto>>> GetAll()
        {
            var empdto = await _employeeServices.GetAll();
            if (empdto == null) return null;
            return Ok(empdto);
        }

        [HttpPost]
        public async Task<ActionResult<AddEmployeeDto>> Add(AddEmployeeDto addEmployeeDto)
        {
            await _employeeServices.Add(addEmployeeDto);
            return Ok("Employee Add Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeServices.Delete(id);
            return Ok("Employee deleted successfully.");
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetbyName(string name)
        {
           var empdto= await _employeeServices.GetByName(name);
            if (empdto == null) return null;
            return Ok(empdto);
           
        }
    }
}
