using Company.DataAccess.Data;
using Company.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var prod = await GetProductById(id);
            if (prod != null)
            {
                throw new KeyNotFoundException("Product not found.!!");
            }
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
       => await _context.Set<Product>().ToListAsync();

        public async Task<IEnumerable<Product>> GetExpiringProducts()
        {
            var currentDate = DateTime.Now;
            var weekFromNow = currentDate.AddDays(7);

            return await _context.Products
            .Where(p => p.ExpDate <= weekFromNow)
            .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (prod == null)
            {
                throw new KeyNotFoundException("Product not found.!! Please Enter Valid Id");
            }
            return prod;
        }

        public async Task Update(Product product)
        {
            var existingProduct = await GetProductById(product.Id);
            if (existingProduct != null) throw new KeyNotFoundException("Product not found.!! Please Enter Valid Id");
            existingProduct.ProductName = product.ProductName;
            existingProduct.VendorName = product.VendorName;
            existingProduct.Qty = product.Qty;
            existingProduct.Price = product.Price;
            existingProduct.Tax = product.Tax;
            existingProduct.ProductionDate = product.ProductionDate;
            existingProduct.ExpDate = product.ExpDate;
            existingProduct.Id = product.Id;
            existingProduct.Weight = product.Weight;
            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();

        }
    }
}
