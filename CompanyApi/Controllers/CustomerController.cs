using Company.Business.Dto.Customer;
using Company.Business.Dto.Employee;
using Company.Business.Service.CustomerService;
using Company.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService service)
        {
            _customerService = service;
        }
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCustomerDto>>> GetCustomers()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCustomerDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] ReadCustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest("Customer id in the URL does not match customer id in the request body");
            }

            try
            {
                await _customerService.UpdateCustomerAsync(id, customerDto);
                return Ok("Customer updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<AddCustomerDto>> PostCustomer(AddCustomerDto customerDto)
        {
            //await _customerService.AddCustomerAsync(customerDto);
            //return CreatedAtAction("GetCustomer", new { id = customerDto.Id }, customerDto);
            await _customerService.Add(customerDto);
            return Ok("Customer Add Successfully");
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }

    }
}
