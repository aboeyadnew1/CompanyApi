using Company.Business.Dto.Product;
using Company.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.ProductService
{
    public interface IProductService
    {
        Task<List<ReadProductDto>> GetExpiringProducts();
        Task<IEnumerable<ReadProductDto>> GetAllProducts();
        Task<ReadProductDto> GetProductById(int id);
        Task Add(AddProductDto addProductDto);
        Task Update(ReadProductDto readProductDto);
        Task Delete(int id);
    }
}
