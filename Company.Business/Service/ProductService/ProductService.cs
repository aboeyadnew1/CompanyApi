using Company.Business.Dto.Department;
using Company.Business.Dto.Product;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.ProductRepo;

namespace Company.Business.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(AddProductDto addProductDto)
        {
          
            var prod = new Product
            {
                ProductName = addProductDto.ProductName,
                Price = addProductDto.Price,
                Tax = addProductDto.Tax,
                Qty = addProductDto.Qty,
                ProductionDate = addProductDto.ProductionDate,
                ExpDate = addProductDto.ExpDate,
                VendorName = addProductDto.VendorName,
                Weight = addProductDto.Weight
               
            };
            await _productRepository.Add(prod);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<ReadProductDto>> GetAllProducts()
        {

            var prod = await _productRepository.GetAllProducts();
            // Maping From Db to Dto
            return prod.Select(x => new ReadProductDto
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Weight = x.Weight,
                ExpDate = x.ExpDate,
                ProductionDate = x.ProductionDate,
                Qty = x.Qty,
                Tax = x.Tax,
                VendorName = x.VendorName,
                Id = x.Id
            }).ToList();
        }

        public async Task<List<ReadProductDto>> GetExpiringProducts()
        {
            var products = await _productRepository.GetExpiringProducts();
            return products.Select(p => new ReadProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                Tax = p.Tax,
                VendorName = p.VendorName,
                Qty = p.Qty,
                Weight = p.Weight,
                ProductionDate = p.ProductionDate,
                ExpDate = p.ExpDate
            }).ToList();
        }

        public async Task<ReadProductDto> GetProductById(int id)
        {
            var prod = await _productRepository.GetProductById(id);
            if (prod == null) throw new KeyNotFoundException("Department not found.");
            return new ReadProductDto
            {
                Qty = prod.Qty,
                Weight = prod.Weight,
                ProductName = prod.ProductName,
                Id = prod.Id,
                VendorName = prod.VendorName,
                ProductionDate = prod.ProductionDate,
                ExpDate = prod.ExpDate,
                Price = prod.Price,
                Tax = prod.Tax,

            };
        }

        public async Task Update(ReadProductDto readProductDto)
        {
            var existingProduct = await _productRepository.GetProductById(readProductDto.Id);
            if (existingProduct != null) throw new KeyNotFoundException("Department not found.");
            existingProduct.ProductionDate = readProductDto.ProductionDate;
            existingProduct.ProductName = readProductDto.ProductName;
            existingProduct.ProductionDate = readProductDto.ProductionDate;
            existingProduct.ExpDate = readProductDto.ExpDate;
            existingProduct.Tax = readProductDto.Tax;
            existingProduct.Price = readProductDto.Price;
            existingProduct.VendorName = readProductDto.VendorName;
            existingProduct.Qty = readProductDto.Qty;
        }
    }








}
