using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("product-types")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductTypes()
        {
            List<ProductTypeResponse> productTypes;
            try
            {
                productTypes = await _productTypeService.GetProductTypes();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(productTypes);
        }

        [HttpGet("{producttypeid}")]
        public async Task<IActionResult> GetProductType(int producttypeid)
        {
            ProductTypeResponse productType;
            try
            {
                productType = await _productTypeService.GetProductType(producttypeid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(productType);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductType(ProductTypeRequest productTypeDetails)
        {
            ProductTypeResponse addedProductType;
            try
            {
                addedProductType = await _productTypeService.PostProductType(productTypeDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostProductType), addedProductType);
        }
    }
}
