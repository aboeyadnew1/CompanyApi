using Company.Business.Dto.Order;
using Company.Business.Service.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadOrderDto>>> GetOrders()
        {
            return Ok(await _orderServices.GetAllOrdersAsync());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadOrderDto>> GetOrder(int id)
        {
            var Order = await _orderServices.GetOrderByIdAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] ReadOrderDto OrderDto)
        {
            if (id != OrderDto.Id)
            {
                return BadRequest("Order id in the URL does not match Order id in the request body");
            }

            try
            {
                await _orderServices.UpdateOrderAsync(id, OrderDto);
                return Ok("Order updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<AddOrderDto>> PostOrder(AddOrderDto OrderDto)
        {
            //await _orderServices.AddOrderAsync(OrderDto);
            //return CreatedAtAction("GetOrder", new { id = OrderDto.Id }, OrderDto);
            await _orderServices.Add(OrderDto);
            return Ok("Order Add Successfully");
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var Order = await _orderServices.GetOrderByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            await _orderServices.DeleteOrderAsync(id);

            return NoContent();
        }
    }
}
