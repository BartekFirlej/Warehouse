using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IProductTypeService
    {
        public Task<List<ProductTypeResponse>> GetProductTypes();
        public Task<ProductTypeResponse> GetProductType(int productTypeId);
        public Task<ProductType> CheckProductType(int productTypeId);
        public Task<ProductTypeResponse> PostProductType(ProductTypeRequest productTypeDetails);
    }
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<List<ProductTypeResponse>> GetProductTypes()
        {
            var productTypes = await _productTypeRepository.GetProductTypes();
            if (!productTypes.Any())
                throw new Exception("Not found any product types.");
            return productTypes;
        }

        public async Task<ProductTypeResponse> GetProductType(int productTypeId)
        {
            var productType = await _productTypeRepository.GetProductType(productTypeId);
            if (productType == null)
                throw new Exception(String.Format("Not found any product type with id {0}.", productTypeId));
            return productType;
        }

        public async Task<ProductType> CheckProductType(int productTypeId)
        {
            var productType = await _productTypeRepository.CheckProductType(productTypeId);
            if (productType == null)
                throw new Exception(String.Format("Not found any product type with id {0}.", productTypeId));
            return productType;
        }

        public async Task<ProductTypeResponse> PostProductType(ProductTypeRequest productTypeDetails)
        {
            var addedProductType = await _productTypeRepository.PostProductType(productTypeDetails);
            return ProductType.ProductTypeToResponseDTO(addedProductType);
        }
    }
}
