using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IProductRepository
    {
        public Task<List<ProductResponse>> GetProducts();
        public Task<ProductResponse> GetProduct(int productId);
        public Task<Product> CheckProduct(int productId);
        public Task<Product> PostProduct(ProductRequest productDetails);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDbContext _context;

        public ProductRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => Product.ProductToResponseDTO(p))
                .ToListAsync();
        }

        public async Task<ProductResponse> GetProduct(int productId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.ProductId == productId)
                .Select(p => Product.ProductToResponseDTO(p))
                .FirstOrDefaultAsync();
        }

        public async Task<Product> CheckProduct(int productId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> PostProduct(ProductRequest productDetails)
        {
            var productToAdd = new Product
            {
                ProductName = productDetails.ProductName,
                Price = productDetails.Price,
                ProductTypeId = productDetails.ProductTypeId
            };
            await _context.Products.AddAsync(productToAdd);
            await _context.SaveChangesAsync();
            return productToAdd;
        }
    }
}
