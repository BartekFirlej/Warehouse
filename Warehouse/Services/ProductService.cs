using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetProducts();
        public Task<ProductResponse> GetProduct(int productId);
        public Task<Product> CheckProduct(int productId);
        public Task<ProductResponse> PostProduct(ProductRequest productDetails);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeService _productTypeService;

        public ProductService(IProductRepository productRepository, IProductTypeService productTypeService)
        {
            _productRepository = productRepository;
            _productTypeService = productTypeService;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            if (!products.Any())
                throw new Exception("Not found any products.");
            return products;
        }

        public async Task<ProductResponse> GetProduct(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null)
                throw new Exception(String.Format("Not found any product with id {0}.", productId));
            return product;
        }

        public async Task<Product> CheckProduct(int productId)
        {
            var product = await _productRepository.CheckProduct(productId);
            if (product == null)
                throw new Exception(String.Format("Not found any product with id {0}.", productId));
            return product;
        }

        public async Task<ProductResponse> PostProduct(ProductRequest productDetails)
        {
            await _productTypeService.CheckProductType(productDetails.ProductTypeId);
            return await _productRepository.PostProduct(productDetails);
        }
    }
}
