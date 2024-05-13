using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            List<ProductResponse> products;
            try
            {
                products = await _productService.GetProducts();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductsWithProductTypes()
        {
            List<ProductWithProductTypeResponse> products;
            try
            {
                products = await _productService.GetProductsWithProductTypes();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(products);
        }

        [HttpGet("{productid}")]
        public async Task<IActionResult> GetProduct(int productid)
        {
            ProductResponse product;
            try
            {
                product = await _productService.GetProduct(productid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductRequest productDetails)
        {
            ProductResponse addedProduct;
            try
            {
                addedProduct = await _productService.PostProduct(productDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostProduct), addedProduct);
        }
    }
}
