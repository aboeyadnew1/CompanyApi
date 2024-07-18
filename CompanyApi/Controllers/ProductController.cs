using Company.Business.Dto.Product;
using Company.Business.Service.ProductService;
using Company.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddProductDto product)
        {
            await _productService.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ReadProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.Delete(id);
            return NoContent();
        }

        [HttpGet("expiring")]
        public async Task<ActionResult<List<ReadProductDto>>> GetExpiringProducts()
        {
            var products = await _productService.GetExpiringProducts();
            return Ok(products);
        }
    }
}
