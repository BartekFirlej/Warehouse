using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IProductTypeRepository
    {
        public Task<List<ProductTypeResponse>> GetProductTypes();
        public Task<ProductTypeResponse> GetProductType(int productTypeId);
        public Task<ProductType> PostProductType(ProductTypeRequest productTypeDetails);
    }

    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly WarehouseDbContext _context;

        public ProductTypeRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductTypeResponse>> GetProductTypes()
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .Select(p => ProductType.ProductToResponseDTO(p))
                .ToListAsync();
        }

        public async Task<ProductTypeResponse> GetProductType(int productTypeId)
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .Where(p => p.ProductTypeId == productTypeId)
                .Select(p => ProductType.ProductToResponseDTO(p))
                .FirstOrDefaultAsync();
        }

        public async Task<ProductType> PostProductType(ProductTypeRequest productTypeDetails)
        {
            var productTypeToadd = new ProductType
            {
                ProductTypeName = productTypeDetails.ProductTypeName
            };
            await _context.ProductTypes.AddAsync(productTypeToadd);
            await _context.SaveChangesAsync();
            return productTypeToadd;
        }
    }
}
